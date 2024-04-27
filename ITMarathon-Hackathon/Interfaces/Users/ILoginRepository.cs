using ITMarathon_Hackathon.DTOs.Users;

namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface ILoginRepository
    {
        Task<int> LoginAsyncRepo(LoginDTO loginDTO);
    }
}