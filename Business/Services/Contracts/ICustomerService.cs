using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface ICustomerService
    {
        Task<Response<CustomerDTO>> Add(CustomerDTO customerDTO);
        Task<Response<CustomerDTO>> Update(CustomerDTO customerDTO);
        Task<Response<bool>> Delete(CustomerDTO customerDTO);
        Task<Response<CustomerDTO>> Get(int id);
        Task<Response<List<CustomerDTO>>> GetAll(Expression<Func<Customer, bool>>? predicate = null);
    }
}