using Business.Services.Contracts;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService service) : ControllerBase
    {
        private readonly IStoreService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(StoreDTO storeDTO) => Ok(await _service.Add(storeDTO));
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
        public async Task<IActionResult> Update(StoreDTO storeDTO) => Ok(await _service.Update(storeDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(StoreDTO storeDTO) => Ok(await _service.Delete(storeDTO));
        #endregion

    }
}
