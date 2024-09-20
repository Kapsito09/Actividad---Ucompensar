using Business.Services.Contracts;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductDTO productDTO) => Ok(await _service.Add(productDTO));
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
        public async Task<IActionResult> Update(ProductDTO productDTO) => Ok(await _service.Update(productDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ProductDTO productDTO) => Ok(await _service.Delete(productDTO));
        #endregion

    }
}
