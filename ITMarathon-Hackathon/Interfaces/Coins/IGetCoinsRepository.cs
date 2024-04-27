using ITMarathon_Hackathon.DTOs.Coins;

namespace ITMarathon_Hackathon.Interfaces.Coins
{
    public interface IGetCoinsRepository
    {
        Task<IEnumerable<GetCoinsDTO>> GetCoinsAsyncRepo();
    }
}