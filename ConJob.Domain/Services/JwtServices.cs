using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;


namespace ConJob.Domain.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IJwtRepository _jwtRepository;

        public JwtServices(IMapper mapper, AppDbContext context, IJwtRepository jwtRepository)
        {
            _mapper = mapper;
            _context = context;
            _jwtRepository = jwtRepository;
        }
        public async Task InsertJWTToken(JwtDTO jwt)
        {
            var needToAdd = _mapper.Map<JWTModel>(jwt);
            if (needToAdd != null)
            {
                await _jwtRepository.AddAsync(needToAdd);
            }
            else
            {
                throw new Exception("Loi: cap cuu!");
            }
        }
    }
}
