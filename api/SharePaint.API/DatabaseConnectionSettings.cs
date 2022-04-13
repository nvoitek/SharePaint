using SharePaint.Repository.Interfaces;

namespace SharePaint.API
{
    public class DatabaseConnectionSettings : IDatabaseConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
