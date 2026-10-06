using Microsoft.EntityFrameworkCore;
using System;

namespace Ribbons.Data
{
    public abstract class Database : DbContext
    {
        protected DatabaseEngine DatabaseEngine { get; set; }

        protected Database(DatabaseEngine databaseEngine)
        {
            DatabaseEngine = databaseEngine;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (DatabaseEngine)
            {
                case DatabaseEngine.MsSql:
                    optionsBuilder.UseSqlServer();
                    break;
                case DatabaseEngine.MySql:
                    optionsBuilder.UseMySQL();
                    break;
                case DatabaseEngine.PostgreSql:
                    optionsBuilder.UseNpgsql();
                    break;
                case DatabaseEngine.Sqlite:
                    optionsBuilder.UseSqlite();
                    break;
                default:
                    throw new NotSupportedException();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}