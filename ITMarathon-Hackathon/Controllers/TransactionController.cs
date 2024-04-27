using ITMarathon_Hackathon.DTOs.Transactions;
using ITMarathon_Hackathon.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace ITMarathon_Hackathon.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly IMakeTransactionRepository _makeTransactionRepository;

        public TransactionController(IMakeTransactionRepository makeTransactionRepository)
        {
            _makeTransactionRepository = makeTransactionRepository;
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
    }
}
