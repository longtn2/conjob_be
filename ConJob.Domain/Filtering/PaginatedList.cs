﻿using Microsoft.EntityFrameworkCore;

namespace ConJob.Domain.Filtering
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage {  get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) 
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync(); //count số users được lấy ra
            var items = await source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
