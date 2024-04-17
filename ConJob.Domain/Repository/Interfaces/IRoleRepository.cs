﻿using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IRoleRepository : IGenericRepository<RoleModel>
    {
        Task<RoleModel> getRoleByLevel_NameAsync(int level, string roleName);
        Task<RoleModel> getRoleByNameAsync(string roleName);
        Task<RoleModel> getRoleExceptAdmin( string roleName);
        Task<RoleModel> getRoleByName(string roleName);
    }
}
