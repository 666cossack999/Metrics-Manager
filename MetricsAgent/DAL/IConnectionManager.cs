using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public interface IConnectionManager
    {
        string CreateOpenedConnection();
        SQLiteConnection GetOpenedConnection();
    }
}