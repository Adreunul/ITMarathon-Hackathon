using ITMarathon_Hackathon.DTOs.Coins;

namespace ITMarathon_Hackathon.Interfaces.Coins
{
    public interface IUserCoinsRepository
    {
        Task<IEnumerable<UserCoinsDTO>> GetUserCoinsAsyncRepo(int userId);
    }
}