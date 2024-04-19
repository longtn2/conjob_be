using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ConJob.Domain.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        protected readonly IMapper _mapper;
        public GenericRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex) {
                throw;
            }
            
        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            _context.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public  Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }
        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return _context.SaveChangesAsync();
        }

    }
}
