using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseProvider<TDatabase, TDatabaseConfig> : IDatabaseProvider<TDatabase> 
        where TDatabase : Database
        where TDatabaseConfig : DatabaseConfig
    {
        protected TDatabaseConfig Configuration { get; }

        protected DatabaseProvider(TDatabaseConfig configuration)
        {
            Configuration = configuration;
        }

        public TDatabase GetDatabase()
        {
            TDatabase instance = CreateInstance();
            instance.SetConnectionString(Configuration.ConnectionString);
            return instance;
        }

        public async Task<TDatabase> GetDatabaseAsync()
        {
            return await Task.FromResult(GetDatabase());
        }

        public void Migrate()
        {
            TDatabase instance = GetDatabase();
            instance.Database.Migrate();
        }

        public async Task MigrateAsync()
        {
            TDatabase instance = await GetDatabaseAsync();
            await instance.Database.MigrateAsync();
        }

        protected abstract TDatabase CreateInstance();
    }
}