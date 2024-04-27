using ITMarathon_Hackathon.DTOs.Users;

namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IRegisterRepository
    {
        Task<int> RegisterUserAsyncRepo(RegisterDTO registerDTO);
    }
}