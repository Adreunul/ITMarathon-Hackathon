using ITMarathon_Hackathon.Interfaces.Coins;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITMarathon_Hackathon.Controllers
{
    public class CoinController : ControllerBase
    {
        private readonly IUserCoinsRepository _userCoinsRepository;
        private readonly IGetCoinsRepository _getCoinsRepository;

        public CoinController(IUserCoinsRepository userCoinsRepository, IGetCoinsRepository getCoinsRepository)
        {
            _userCoinsRepository = userCoinsRepository;
            _getCoinsRepository = getCoinsRepository;
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

        [HttpGet]
        [Route("GetCoins")]
        public async Task<IActionResult> GetCoinsAsync()
        {
            var result = await _getCoinsRepository.GetCoinsAsyncRepo();

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Get coins failed.");
        }

    }
}
