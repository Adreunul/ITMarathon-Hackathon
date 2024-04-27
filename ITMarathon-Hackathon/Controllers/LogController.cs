using ITMarathon_Hackathon.DTOs.Logs;
using ITMarathon_Hackathon.Interfaces.Logs;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class LogController : ControllerBase
    {
        private readonly IGetLogsRepository _getLogsRepository;
        public LogController(IGetLogsRepository getLogsRepository)
        {
            _getLogsRepository = getLogsRepository;
        }

        [HttpGet]
        [Route("GetLogs")]
        public async Task<IActionResult> GetLogsAsync()
        {
            var result = await _getLogsRepository.GetLogsAsyncRepo();
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
