using Microsoft.AspNetCore.Mvc;
using players_api.Data;
using players_api.Models;
using System.Threading.Tasks;
using players_api.Dtos.User;

namespace players_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public UserController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserDto request)
        {
            var response = await _authRepo.Register(new User { Username = request.Username }, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UsertLoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
