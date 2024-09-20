using AutoMapper;
using Business.Services.Contracts;
using DAL.Repository.Contract;
using DataAccess.Models;
using DTO;
using System.Linq.Expressions;

namespace Business.Services
{
    public class StoreCommentService(IGenericRepository<StoreComment> repository, IMapper mapper) : IStoreCommentService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<StoreComment> _repository = repository;

        public async Task<Response<StoreCommentDTO>> Add(StoreCommentDTO storeCommentDTO)
        {
            Response<StoreCommentDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<StoreComment>(storeCommentDTO));
                response.Value = _mapper.Map<StoreCommentDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(StoreCommentDTO storeCommentDTO)
        {
            Response<bool> response = new();

            try
            {
                response.Status = await _repository.Delete(_mapper.Map<StoreComment>(storeCommentDTO));
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<StoreCommentDTO>> Get(int id)
        {
            Response<StoreCommentDTO> response = new();

            try
            {
                response.Value = _mapper.Map<StoreCommentDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<StoreCommentDTO>>> GetAll(Expression<Func<StoreComment, bool>>? predicate = null)
        {
            Response<List<StoreCommentDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<StoreCommentDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<StoreCommentDTO>> Update(StoreCommentDTO storeCommentDTO)
        {
            Response<StoreCommentDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<StoreComment>(storeCommentDTO));
                response.Value = storeCommentDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}