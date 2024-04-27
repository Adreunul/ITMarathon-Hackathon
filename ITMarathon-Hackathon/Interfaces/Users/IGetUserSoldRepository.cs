namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IGetUserSoldRepository
    {
        Task<double> GetUserSoldAsyncRepo(int idUser);
    }
}