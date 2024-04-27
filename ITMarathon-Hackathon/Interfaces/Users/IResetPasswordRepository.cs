using ITMarathon_Hackathon.DTOs.Users;

namespace ITMarathon_Hackathon.Interfaces.Users
{
    public interface IResetPasswordRepository
    {
        Task<int> ResetPasswordAsyncRepo(ResetPasswordDTO resetPasswordDTO);
    }
}