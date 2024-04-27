using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IResetPasswordRepository _resetPasswordRepository;
        private readonly IRegisterRepository _registerRepository;
        private readonly IAddUserFundsRepository _addUserFundsRepository;

        public UserController(ILoginRepository loginRepository,
            IRegisterRepository registerRepository,
            IResetPasswordRepository resetPasswordRepository,
            IAddUserFundsRepository addUserFundsRepository)
        {
            _loginRepository = loginRepository;
            _registerRepository = registerRepository;
            _resetPasswordRepository = resetPasswordRepository;
            _addUserFundsRepository = addUserFundsRepository;
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

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterDTO registerDTO)
        {
            var userId = await _registerRepository.RegisterUserAsyncRepo(registerDTO);

            if (userId > 0)
                return Ok(userId);
            else
                return BadRequest("Registration failed.");
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

        [HttpPost]
        [Route("AddUserFunds")]
        public async Task<IActionResult> AddUserFundsAsync([FromBody] AddUserFundsDTO addUserFundsDTO)
        {
            var result = await _addUserFundsRepository.AddUserFundsAsyncRepo(addUserFundsDTO);

            if (result > 0)
                return Ok(result);
            else
                return BadRequest("Adding funds failed");
        }
    }
}
