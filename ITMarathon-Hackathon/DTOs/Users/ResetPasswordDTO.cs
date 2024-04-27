namespace ITMarathon_Hackathon.DTOs.Users
{
    public class ResetPasswordDTO
    {
        public string username { get; set; }
        public string oldSafeword { get; set; }
        public string newPassword { get; set; }
        public string newSafeword { get; set; }
    }
}
