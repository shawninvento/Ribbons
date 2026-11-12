using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Ribbons.Data
{
    public abstract class DatabaseProvider<TDatabase, TDatabaseConfig> : IDatabaseProvider<TDatabase> 
        where TDatabase : Database
        where TDatabaseConfig : DatabaseConfig
    {
        protected TDatabaseConfig Configuration { get; }

        protected DatabaseProvider(IOptions<TDatabaseConfig> configuration)
        {
            Configuration = configuration.Value;
        }

        public TDatabase GetDatabase()
        {
            return CreateInstance();
        }

        public async Task<TDatabase> GetDatabaseAsync()
        {
            return await Task.FromResult(CreateInstance());
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