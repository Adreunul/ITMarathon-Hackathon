using Dapper;
using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Users;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class ResetPasswordRepository : IResetPasswordRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ResetPasswordRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> ResetPasswordAsyncRepo(ResetPasswordDTO resetPasswordDTO)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Username", resetPasswordDTO.username);

            string hashedPassword = HashPassword(resetPasswordDTO.newPassword);
            parameters.Add("@NewPassword", hashedPassword);

            string hashedNewSafeWord = HashPassword(resetPasswordDTO.newSafeword);
            parameters.Add("@NewSafeword", hashedNewSafeWord);

            string hashedOldSafeWord = HashPassword(resetPasswordDTO.oldSafeword);
            parameters.Add("@OldSafeword", hashedOldSafeWord);

            parameters.Add("@IdUser", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UserResetPass", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@IdUser");
            }
        }

        private string HashPassword(string pasword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pasword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
