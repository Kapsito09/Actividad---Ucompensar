using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services.Contracts
{
    public interface IUserService
    {
        Task<Response<UserDTO>> Add(UserDTO UserDTO);
        Task<Response<UserDTO>> Update(UserDTO UserDTO);
        Task<Response<bool>> Delete(UserDTO UserDTO);
        Task<Response<UserDTO>> Get(int id);
        Task<Response<List<UserDTO>>> GetAll(Expression<Func<User, bool>>? predicate = null);
    }
}