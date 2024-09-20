using System.Linq.Expressions;

namespace DAL.Repository.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate);
        Task<TModel> Add(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
        Task<IQueryable<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? predicate = null);
    }
}