using ITMarathon_Hackathon.DTOs.Users;

namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IGetUsersRepository
    {
        Task<IEnumerable<GetUsersDTO>> GetUsersAsyncRepo();
    }
}