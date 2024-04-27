using System.Data;

namespace ITMarathon_Hackathon.Interfaces
{
    public interface IDbConnectionFactory
    {
        public IDbConnection ConnectToDataBase();
    }
}
