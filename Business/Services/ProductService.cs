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
    public class ProductService(IGenericRepository<Product> repository, IMapper mapper) : IProductService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericRepository<Product> _repository = repository;

        //public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        //{
        //    _mapper = mapper;
        //    _repository = repository;
        //}

        public async Task<Response<ProductDTO>> Add(ProductDTO productDTO)
        {
            Response<ProductDTO> response = new();

            try
            {
                var result = await _repository.Add(_mapper.Map<Product>(productDTO));
                response.Value = _mapper.Map<ProductDTO>(result);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(ProductDTO productDTO)
        {
            Response<bool> response = new();

            try
            {
                response.Status = await _repository.Delete(_mapper.Map<Product>(productDTO));
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<ProductDTO>> Get(int id)
        {
            Response<ProductDTO> response = new();

            try
            {
                response.Value = _mapper.Map<ProductDTO>(await _repository.GetAsync(x => x.Id == id));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<ProductDTO>>> GetAll(Expression<Func<Product, bool>>? predicate = null)
        {
            Response<List<ProductDTO>> response = new();

            try
            {
                response.Value = _mapper.Map<List<ProductDTO>>(await _repository.GetAllAsync(predicate));
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }

        public async Task<Response<ProductDTO>> Update(ProductDTO productDTO)
        {
            Response<ProductDTO> response = new();

            try
            {
                response.Status = await _repository.Update(_mapper.Map<Product>(productDTO));
                response.Value = productDTO;
            }
            catch (Exception ex)
            {
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}