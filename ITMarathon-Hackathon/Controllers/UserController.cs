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
        private readonly IGetUserSoldRepository _getUserSoldRepository;
        private readonly IGetUserSoldFromCoinsRepository _getUserSoldFromCoinsRepository;

        public UserController(ILoginRepository loginRepository,
            IRegisterRepository registerRepository,
            IResetPasswordRepository resetPasswordRepository,
            IAddUserFundsRepository addUserFundsRepository,
            IGetUserSoldRepository getUserSoldRepository,
            IGetUserSoldFromCoinsRepository getUserSoldFromCoinsRepository)
        {
            _loginRepository = loginRepository;
            _registerRepository = registerRepository;
            _resetPasswordRepository = resetPasswordRepository;
            _addUserFundsRepository = addUserFundsRepository;
            _getUserSoldRepository = getUserSoldRepository;
            _getUserSoldFromCoinsRepository = getUserSoldFromCoinsRepository;
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

        [HttpGet]
        [Route("GetUserSold")]
        public async Task<IActionResult> GetUserSoldAsync(int idUser)
        {
            var sold = await _getUserSoldRepository.GetUserSoldAsyncRepo(idUser);

            if (sold >= 0)
                return Ok(sold);
            else
                return BadRequest("Getting sold failed");
        }

        [HttpGet]
        [Route("GetUserSoldFromCoins")]
        public async Task<IActionResult> GetUserSoldFromCoinsAsync(int idUser)
        {
            var sold = await _getUserSoldFromCoinsRepository.GetUserSoldFromCoinsAsyncRepo(idUser);

            if (sold >= 0)
                return Ok(sold);
            else
                return BadRequest("Getting sold failed");
        }
    }
}
