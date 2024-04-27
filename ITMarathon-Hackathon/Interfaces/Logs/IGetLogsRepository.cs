using ITMarathon_Hackathon.DTOs.Logs;

namespace ITMarathon_Hackathon.Interfaces.Logs
{
    public interface IGetLogsRepository
    {
        Task<IEnumerable<GetLogsDTO>> GetLogsAsyncRepo();
    }
}