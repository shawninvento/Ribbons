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
                case DatabaseEngine.Npgsql:
                    throw new NotSupportedException($"{DatabaseEngine} is not supported at this time");
                case DatabaseEngine.Sqlite:
                    optionsBuilder.UseSqlite();
                    break;
            }
        }


    }
}