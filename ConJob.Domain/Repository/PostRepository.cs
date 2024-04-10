using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class PostRepository : GenericRepository<PostModel>, IPostRepository
    {
        public PostRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
