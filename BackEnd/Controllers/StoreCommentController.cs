using Business.Services.Contracts;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class StoreCommentController(IStoreCommentService service) : ControllerBase
    {
        private readonly IStoreCommentService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(StoreCommentDTO storeCommentDTO) => Ok(await _service.Add(storeCommentDTO));
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
        public async Task<IActionResult> Update(StoreCommentDTO storeCommentDTO) => Ok(await _service.Update(storeCommentDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(StoreCommentDTO storeCommentDTO) => Ok(await _service.Delete(storeCommentDTO));
        #endregion

    }
}
