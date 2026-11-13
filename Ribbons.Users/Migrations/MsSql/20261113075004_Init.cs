using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ribbons.Users.Migrations.MsSql;

/// <inheritdoc />
public partial class _20261113075004_Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "t_user",
            columns: table => new
            {
                user_id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                created_date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
