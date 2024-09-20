using AutoMapper;
using Business.Services.Contracts;
using DAL.Repository.Contract;
using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services
{
    public class UserService(IGenericRepository<User> repository, IMapper mapper) : IUserService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<User> _repository = repository;

        public async Task<Response<UserDTO>> Add(UserDTO userDTO)
        {
            Response<UserDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<User>(userDTO));
                response.Value = _mapper.Map<UserDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(UserDTO userDTO)
        {
            Response<bool> response = new();

            try
            {
                response.Status = await _repository.Delete(_mapper.Map<User>(userDTO));
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<UserDTO>> Get(int id)
        {
            Response<UserDTO> response = new();

            try
            {
                response.Value = _mapper.Map<UserDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<UserDTO>>> GetAll(Expression<Func<User, bool>>? predicate = null)
        {
            Response<List<UserDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<UserDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<UserDTO>> Update(UserDTO userDTO)
        {
            Response<UserDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<User>(userDTO));
                response.Value = userDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}