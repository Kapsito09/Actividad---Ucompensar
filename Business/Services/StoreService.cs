using AutoMapper;
using Business.Services.Contracts;
using DAL.Repository.Contract;
using DataAccess.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class StoreService(IGenericRepository<Store> repository, IMapper mapper) : IStoreService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Store> _repository = repository;

        public async Task<Response<StoreDTO>> Add(StoreDTO storeDTO)
        {
            Response<StoreDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<Store>(storeDTO));
                response.Value = _mapper.Map<StoreDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(StoreDTO storeDTO)
        {
            Response<bool> response = new();

            try
            {
                response.Status = await _repository.Delete(_mapper.Map<Store>(storeDTO));
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<StoreDTO>> Get(int id)
        {
            Response<StoreDTO> response = new();

            try
            {
                response.Value = _mapper.Map<StoreDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<StoreDTO>>> GetAll(Expression<Func<Store, bool>>? predicate = null)
        {
            Response<List<StoreDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<StoreDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<StoreDTO>> Update(StoreDTO storeDTO)
        {
            Response<StoreDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<Store>(storeDTO));
                response.Value = storeDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}
