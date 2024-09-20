using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface IStoreService
    {
        Task<Response<StoreDTO>> Add(StoreDTO storeDTO);
        Task<Response<StoreDTO>> Update(StoreDTO storeDTO);
        Task<Response<bool>> Delete(StoreDTO storeDTO);
        Task<Response<StoreDTO>> Get(int id);
        Task<Response<List<StoreDTO>>> GetAll(Expression<Func<Store, bool>>? predicate = null);
    }
}
