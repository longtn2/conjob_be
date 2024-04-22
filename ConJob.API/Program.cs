using ConJob.Data;
using ConJob.Domain.Authentication;
using ConJob.Domain.Encryption;
using ConJob.Domain.Repository.Interface;
using ConJob.Domain.Repository;
using ConJob.Domain.Services;
using ConJob.Entities.Config;
using DataLayer.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ConJob.Domain.Repository.Interfaces;
using AutoMapper;
using ConJob.Domain.AutoMapper;
using ConJob.API;
using ConJob.API.Policy;
using Microsoft.AspNetCore.Authorization;
using ConJob.Domain.Services.Interfaces;
using System.Text.Json.Serialization;
using Hangfire;
using Asp.Versioning;
using ConJob.API.Middleware;
using ConJob.API.Filter.AuthResponsesOperationFilter;
using ConJob.API.Policy.ResultHandler;
using ConJob.API.Error.ValidationError;
using System.Net.Mime;
using ConJob.Domain.Filtering;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Filtering;
using ConJob.Domain.DTOs.Post;

var builder = WebApplication.CreateBuilder(args);

#region Add Config 
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<S3Settings>(builder.Configuration.GetSection("S3Settings"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

#endregion
#region Add Versioning
var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
});

apiVersioningBuilder.AddApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });
#endregion

#region Add DB service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));
#endregion


#region Add JWT Settings 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings")["Secret"] ?? throw new InvalidOperationException("'Secret' not found.")))
        };
    });
#endregion
// Add services to the container.
#region Add Services 
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IPasswordHasher, Bcrypt>();
builder.Services.AddSingleton<IJWTHelper, JWTHelper>();
builder.Services.AddTransient<IEmailSender, EmailSenderServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
builder.Services.AddScoped<IJwtServices, JwtServices>();
builder.Services.AddScoped<IAuthorizationHandler, EmailVerifiedHandler>();
builder.Services.AddTransient<IEmailServices, EmailServices>();
builder.Services.AddScoped<IS3Services,  S3Services>();
builder.Services.AddScoped<IJobServices, JobSevices>();
builder.Services.AddScoped<IFilterHelper<JobDetailsDTO>, FilterHelper<JobDetailsDTO>>();
builder.Services.AddScoped<IFilterHelper<JobDTO>, FilterHelper<JobDTO>>();
builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
#endregion
#region add Hangfire 
builder.Services.AddHangfire(configuration => configuration
                    .UseSqlServerStorage(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddHangfireServer();
#endregion
#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddTransient<IJwtRepository, JwtRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, EmailAuthorizationMiddlewareResultHandler>();
#region Controller Config
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var result = new ValidationFailedResult(context.ModelState);

        // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
        result.ContentTypes.Add(MediaTypeNames.Application.Json);
        result.ContentTypes.Add(MediaTypeNames.Application.Xml);

        return result;
    };
});
#endregion
#region config Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.OperationFilter<AuthResponsesOperationFilter>();
    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\ConJob.API.xml");
});
#endregion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("emailverified", policy => policy.Requirements.Add(new EmailVerifiedRequirement()));
});
#region Auto mapper
builder.Services.AddSingleton(provider => new MapperConfiguration(options =>
{
    options.AddProfile(new MappingProfile(provider.GetService<IPasswordHasher>() ?? throw new InvalidOperationException("Service Not found!")));
})
.CreateMapper());

#endregion
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region some sort of Middleware

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseMiddleware<ValidationExceptionHandlerMiddleware>();
#endregion
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.Run();
