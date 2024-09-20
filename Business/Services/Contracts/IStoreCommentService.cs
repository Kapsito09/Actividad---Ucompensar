using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface IStoreCommentService
    {
        Task<Response<StoreCommentDTO>> Add(StoreCommentDTO storeCommentDTO);
        Task<Response<StoreCommentDTO>> Update(StoreCommentDTO storeCommentDTO);
        Task<Response<bool>> Delete(StoreCommentDTO storeCommentDTO);
        Task<Response<StoreCommentDTO>> Get(int id);
        Task<Response<List<StoreCommentDTO>>> GetAll(Expression<Func<StoreComment, bool>>? predicate = null);
    }
}
