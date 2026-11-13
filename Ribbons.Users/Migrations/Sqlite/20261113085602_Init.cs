using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ribbons.Users.Migrations.Sqlite;

/// <inheritdoc />
public partial class _20261113085602_Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "t_user",
            columns: table => new
            {
                user_id = table.Column<long>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                user_name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                created_date = table.Column<DateTime>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_user", x => x.user_id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_t_user_created_date",
            table: "t_user",
            column: "created_date");

        migrationBuilder.CreateIndex(
            name: "IX_t_user_user_name",
            table: "t_user",
            column: "user_name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "t_user");
    }
}
