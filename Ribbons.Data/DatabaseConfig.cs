namespace Ribbons.Data
{
    public abstract class DatabaseConfig
    {
        /// <summary>
        /// The database engine you intend to use
        /// Currently supported engines include
        /// <list type="bullet">
        /// <item><see cref="DatabaseEngine.MsSql"/></item>
        /// <item><see cref="DatabaseEngine.MySql"/></item>
        /// <item><see cref="DatabaseEngine.Npgsql"/></item>
        /// <item><see cref="DatabaseEngine.Sqlite"/></item>
        /// </list>
        /// </summary>
        public DatabaseEngine DatabaseEngine { get; set; }

        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; set; }
    }
}