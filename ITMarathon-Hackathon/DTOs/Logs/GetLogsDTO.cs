namespace ITMarathon_Hackathon.DTOs.Logs
{
    public class GetLogsDTO
    {
        public DateTime timestamp {  get; set; }
        public string username { get; set; }
        public string operation { get; set; }
        public int status {  get; set; }
    }
}
