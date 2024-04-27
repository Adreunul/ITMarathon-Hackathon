namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface ILogOutRepository
    {
        Task<int> LogOutAsyncRepo(int idUser);
    }
}