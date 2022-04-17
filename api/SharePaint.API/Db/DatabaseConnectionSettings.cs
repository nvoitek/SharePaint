using SharePaint.Repository.Interfaces;

namespace SharePaint.API.Db
{
    public class DatabaseConnectionSettings : IDatabaseConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
