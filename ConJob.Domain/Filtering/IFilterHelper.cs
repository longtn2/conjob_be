﻿using ConJob.Domain.DTOs.Post;
using ConJob.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ConJob.Domain.Filtering
{
    public interface IFilterHelper<T>
    {
        IQueryable<T> ApplySorting(IQueryable<T> entities, string orderByQueryString);
        Task<PagingReturnModel<T>> ApplyPaging(IQueryable<T> source, int pageNumber, int pageSize);
    }
}
