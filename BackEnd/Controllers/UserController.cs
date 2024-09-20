using Business.Services.Contracts;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserDTO userDTO) => Ok(await _service.Add(userDTO));
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
        public async Task<IActionResult> Update(UserDTO userDTO) => Ok(await _service.Update(userDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(UserDTO userDTO) => Ok(await _service.Delete(userDTO));
        #endregion

    }
}
