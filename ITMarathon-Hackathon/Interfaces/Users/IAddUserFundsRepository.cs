using ITMarathon_Hackathon.DTOs.Users;

namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IAddUserFundsRepository
    {
        Task<int> AddUserFundsAsyncRepo(AddUserFundsDTO addUserFundsDTO);
    }
}