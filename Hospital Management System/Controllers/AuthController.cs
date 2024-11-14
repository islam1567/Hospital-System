using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModelDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.Register(model);
            if(!result.IsAuthentication)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModelDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.Login(model);
            if (!result.IsAuthentication)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
