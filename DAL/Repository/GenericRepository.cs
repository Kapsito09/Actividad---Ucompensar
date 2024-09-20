using DAL.Repository.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<TModel>(Actividad1dbContext context) : IGenericRepository<TModel> where TModel : class
    {
        private readonly Actividad1dbContext _context = context;

        public async Task<TModel> Add(TModel model)
        {
            try
            {
                await _context.Set<TModel>().AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _context.Set<TModel>().Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? predicate = null)
        {
            try
            {
                IQueryable<TModel> query = predicate == null ? _context.Set<TModel>() : _context.Set<TModel>().Where(predicate);
                return query;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel?> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            try
            {
                return await _context.Set<TModel>().Where(predicate).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(TModel model)
        {
            try
            {
                _context.Set<TModel>().Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
