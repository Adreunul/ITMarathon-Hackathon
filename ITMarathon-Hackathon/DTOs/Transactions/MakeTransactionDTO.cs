namespace ITMarathon_Hackathon.DTOs.Transactions
{
    public class MakeTransactionDTO
    {
        public int IdUser { get; set; }
        public int IdCoin { get; set; }
        public float quantity { get; set; }
        public float coinPriceATM { get; set; }
    }
}
