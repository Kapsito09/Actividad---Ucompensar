using Business.Services.Contracts;
using DataAccess.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCommentController(IProductCommentService service) : ControllerBase
    {
        private readonly IProductCommentService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductCommentDTO productCommentDTO) => Ok(await _service.Add(productCommentDTO));
        #endregion

        #region Get
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));
        #endregion

        #region GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        #endregion

        #region Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductCommentDTO productCommentDTO) => Ok(await _service.Update(productCommentDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ProductCommentDTO productCommentDTO) => Ok(await _service.Delete(productCommentDTO));
        #endregion

    }
}
