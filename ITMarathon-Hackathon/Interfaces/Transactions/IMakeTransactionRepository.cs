using ITMarathon_Hackathon.DTOs.Transactions;

namespace ITMarathon_Hackathon.Interfaces.Transactions
{
    public interface IMakeTransactionRepository
    {
        Task<int> MakeTransactionAsyncRepo(MakeTransactionDTO makeTransactionDTO);
    }
}