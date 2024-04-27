using ITMarathon_Hackathon.DTOs;

namespace ITMarathon_Hackathon.Interfaces
{
    public interface ILoginRepository
    {
        Task<int> LoginAsyncRepo(LoginDTO loginDTO);
    }
}