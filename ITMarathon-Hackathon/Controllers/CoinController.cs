using ITMarathon_Hackathon.Interfaces.Coins;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class CoinController : ControllerBase
    {
        private readonly IGetCoinsRepository _getCoinsRepository;
        public CoinController(IGetCoinsRepository getCoinsRepository)
        {
            _getCoinsRepository = getCoinsRepository;
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
