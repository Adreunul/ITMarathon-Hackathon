using ITMarathon_Hackathon.DTOs.Transactions;
using ITMarathon_Hackathon.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly IMakeTransactionRepository _makeTransactionRepository;
        private readonly IGetTransactionCommissionRepository _getTransactionCommissionRepository;

        public TransactionController(IMakeTransactionRepository makeTransactionRepository,
            IGetTransactionCommissionRepository getTransactionCommissionRepository)
        {
            _makeTransactionRepository = makeTransactionRepository;
            _getTransactionCommissionRepository = getTransactionCommissionRepository;
        }

        [HttpPost]
        [Route("MakeTransaction")]
        public async Task<IActionResult> MakeTransactionAsync([FromBody] MakeTransactionDTO makeTransactionDTO)
        {
            var transactionId = await _makeTransactionRepository.MakeTransactionAsyncRepo(makeTransactionDTO);

            if(transactionId > 0)
                return Ok(transactionId);
            else
                return BadRequest("Transaction failed.");
        }

        [HttpGet]
        [Route("GetTransactionCommission")]
        public async Task<IActionResult> GetTransactionCommissionAsyncRepo(float transactionValue)
        {
            var result = await _getTransactionCommissionRepository.GetTransactionCommissionAsyncRepo(transactionValue);

            if (result > 0)
                return Ok(result);
            else
                return BadRequest("Transaction commission calculation failed");
        }
    }
}
