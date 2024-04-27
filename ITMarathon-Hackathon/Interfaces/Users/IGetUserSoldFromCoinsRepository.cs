namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IGetUserSoldFromCoinsRepository
    {
        Task<double> GetUserSoldFromCoinsAsyncRepo(int idUser);
    }
}