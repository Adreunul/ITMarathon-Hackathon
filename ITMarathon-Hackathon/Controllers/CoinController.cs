using ITMarathon_Hackathon.Interfaces.Coins;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class CoinController : ControllerBase
    {
        private readonly IUserCoinsRepository _userCoinsRepository;

        public CoinController(IUserCoinsRepository userCoinsRepository)
        {
            _userCoinsRepository = userCoinsRepository;
        }

        [HttpGet]
        [Route("GetUserCoins")]
        public async Task<IActionResult> GetUserCoinsAsync(int userId)
        {
            var userCoins = await _userCoinsRepository.GetUserCoinsAsyncRepo(userId);

            if (userCoins != null)
                return Ok(userCoins);
            else
                return BadRequest("User coins not found.");
        }

    }
}