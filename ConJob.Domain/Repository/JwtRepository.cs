﻿using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class JwtRepository : GenericRepository<JWTModel>, IJwtRepository
    {
        public JwtRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
