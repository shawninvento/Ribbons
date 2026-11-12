using System.Threading.Tasks;

namespace Ribbons.Data
{
    public interface IDatabaseProvider<TDatabase> where TDatabase : Database
    {
        TDatabase GetDatabase();
        Task<TDatabase> GetDatabaseAsync();
        void Migrate();
        Task MigrateAsync();
    }
}