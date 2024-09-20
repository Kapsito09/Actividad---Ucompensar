using AutoMapper;
using Business.Services.Contracts;
using DAL.Repository.Contract;
using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CustomerService(IGenericRepository<Customer> repository, IMapper mapper) : ICustomerService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Customer> _repository = repository;

        public async Task<Response<CustomerDTO>> Add(CustomerDTO customerDTO)
        {
            Response<CustomerDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<Customer>(customerDTO));
                response.Value = _mapper.Map<CustomerDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(CustomerDTO customerDTO)
        {
            Response<bool> response = new();

            try
            {
                response.Status = await _repository.Delete(_mapper.Map<Customer>(customerDTO));
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<CustomerDTO>> Get(int id)
        {
            Response<CustomerDTO> response = new();

            try
            {
                response.Value = _mapper.Map<CustomerDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<CustomerDTO>>> GetAll(Expression<Func<Customer, bool>>? predicate = null)
        {
            Response<List<CustomerDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<CustomerDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<CustomerDTO>> Update(CustomerDTO customerDTO)
        {
            Response<CustomerDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<Customer>(customerDTO));
                response.Value = customerDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}