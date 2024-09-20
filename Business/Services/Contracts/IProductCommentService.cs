using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface IProductCommentService
    {
        Task<Response<ProductCommentDTO>> Add(ProductCommentDTO productCommentDTO);
        Task<Response<ProductCommentDTO>> Update(ProductCommentDTO productCommentDTO);
        Task<Response<bool>> Delete(ProductCommentDTO productCommentDTO);
        Task<Response<ProductCommentDTO>> Get(int id);
        Task<Response<List<ProductCommentDTO>>> GetAll(Expression<Func<ProductComment, bool>>? predicate = null);
    }
}
