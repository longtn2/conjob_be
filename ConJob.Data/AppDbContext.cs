using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConJob.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasIndex(p => p.Email).IsUnique();


            modelBuilder.Entity<UserModel>()
                        .HasMany(e => e.UserRoles)
                        .WithOne(e => e.User)
                        .HasForeignKey("UserId")
                        .IsRequired();
            modelBuilder.Entity<RoleModel>()
                    .HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey("RoleId")
                    .IsRequired();
            modelBuilder.Entity<UserModel>()
                    .HasMany(e => e.Jwts)
                    .WithOne(e => e.User)
                    .HasForeignKey("UserId")
                    .IsRequired();

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }


        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<UserRoleModel> UserRole {  get; set; }
        public virtual DbSet<RoleModel> Role { get; set; }

        public virtual DbSet<JWTModel> JWT { get; set; }


        #region Auto add created-time, updated-time
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = now;
                }
                ((BaseModel)entity.Entity).UpdatedAt = now;
            }
        }
        #endregion
    }
}
