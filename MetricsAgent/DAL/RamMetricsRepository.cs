using Dapper;
using MetricsAgent.MetricClasses;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface IRamMetricsRepository : IRepository<RamMetric>
    {
    }
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private ConnectionManager connectionManager = new ConnectionManager();
        public RamMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public IList<RamMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var ConnectionString = connectionManager.GetConnection();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT * FROM metrics WHERE (time >= @fromTime) AND (time <= @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }

    }
}