using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface IProductService
    {
        Task<Response<ProductDTO>> Add(ProductDTO productDTO);
        Task<Response<ProductDTO>> Update(ProductDTO productDTO);
        Task<Response<bool>> Delete(ProductDTO productDTO);
        Task<Response<ProductDTO>> Get(int id);
        Task<Response<List<ProductDTO>>> GetAll(Expression<Func<Product, bool>>? predicate = null);
    }
}