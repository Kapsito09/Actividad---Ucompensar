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
    public class ProductCommentService(IGenericRepository<ProductComment> repository, IMapper mapper) : IProductCommentService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<ProductComment> _repository = repository;

        public async Task<Response<ProductCommentDTO>> Add(ProductCommentDTO productCommentDTO)
        {
            Response<ProductCommentDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<ProductComment>(productCommentDTO));
                response.Value = _mapper.Map<ProductCommentDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(ProductCommentDTO productCommentDTO)
        {
            Response<bool> response = new();

            try
            {
                var result = await _repository.Delete(_mapper.Map<ProductComment>(productCommentDTO));
                response.Status = result;
                response.Value = result;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<ProductCommentDTO>> Get(int id)
        {
            Response<ProductCommentDTO> response = new();

            try
            {
                response.Value = _mapper.Map<ProductCommentDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<ProductCommentDTO>>> GetAll(Expression<Func<ProductComment, bool>>? predicate = null)
        {
            Response<List<ProductCommentDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<ProductCommentDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<ProductCommentDTO>> Update(ProductCommentDTO productCommentDTO)
        {
            Response<ProductCommentDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<ProductComment>(productCommentDTO));
                response.Value = productCommentDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}