namespace ITMarathon_Hackathon.Interfaces.Transactions
{
    public interface IGetTransactionCommissionRepository
    {
        Task<double> GetTransactionCommissionAsyncRepo(float transactionValue);
    }
}