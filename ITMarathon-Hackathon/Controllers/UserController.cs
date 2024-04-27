using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        
        public UserController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            var userId = await _loginRepository.LoginAsyncRepo(loginDTO);
            if (userId > 0)
                return Ok(userId);
            else
                return BadRequest("Login failed.");
        }
    }
}
