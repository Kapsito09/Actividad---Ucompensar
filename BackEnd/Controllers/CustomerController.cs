using Business.Services.Contracts;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        private readonly ICustomerService _service = service;

        #region Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CustomerDTO customerDTO) => Ok(await _service.Add(customerDTO));
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
        public async Task<IActionResult> Update(CustomerDTO customerDTO) => Ok(await _service.Update(customerDTO));
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(CustomerDTO customerDTO) => Ok(await _service.Delete(customerDTO));
        #endregion

    }
}
