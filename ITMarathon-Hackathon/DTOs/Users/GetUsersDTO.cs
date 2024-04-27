namespace ITMarathon_Hackathon.DTOs.Users
{
    public class GetUsersDTO
    {
        public string username {  get; set; }
        public string firstname {  get; set; }
        public string lastname { get; set; }
        public int isLogged { get; set; }
        public float sold { get; set; }
        public float soldInCoins { get; set; }
    }
}
