namespace ITMarathon_Hackathon.DTOs.Coins
{
    public class GetCoinsDTO
    {
        public int IdCoin { get; set; }
        public string name { get; set; }
        public float value { get; set; }
        public float lastChange { get; set; }
        public string icon { get; set; }
    }
}
