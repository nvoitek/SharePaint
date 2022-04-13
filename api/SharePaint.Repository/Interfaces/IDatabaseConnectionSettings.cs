namespace SharePaint.Repository.Interfaces
{
    public interface IDatabaseConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
