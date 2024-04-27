using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IResetPasswordRepository _resetPasswordRepository;
        
        public UserController(ILoginRepository loginRepository, IResetPasswordRepository resetPasswordRepository)
        {
            _loginRepository = loginRepository;
            _resetPasswordRepository = resetPasswordRepository;
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginDTO loginDTO)
        {
            var userId = await _loginRepository.LoginAsyncRepo(loginDTO);
            if (userId > 0)
                return Ok(userId);
            else
                return BadRequest("Login failed.");
        }

        [HttpPatch]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var userId = await _resetPasswordRepository.ResetPasswordAsyncRepo(resetPasswordDTO);
            if (userId > 0)
                return Ok(userId);
            else
                if (userId == -2)
                return BadRequest("Password or safeword should not match the old ones.");
            return BadRequest("User not found or safeword is incorrect");
        }
    }
}
