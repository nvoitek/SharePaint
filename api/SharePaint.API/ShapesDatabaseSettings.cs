namespace SharePaint.API
{
    public class ShapesDatabaseSettings : IConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
