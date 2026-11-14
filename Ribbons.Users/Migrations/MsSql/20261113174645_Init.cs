using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ribbons.Users.Migrations.MsSql;

/// <inheritdoc />
public partial class _20261113174645_Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "t_user_domain",
            columns: table => new
            {
                user_domain_id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                domain_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                created_date = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_user_domain", x => x.user_domain_id);
            });

        migrationBuilder.CreateTable(
            name: "t_user",
            columns: table => new
            {
                user_id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                user_domain_id = table.Column<long>(type: "bigint", nullable: true),
                user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                created_date = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_user", x => x.user_id);
                table.ForeignKey(
                    name: "FK_t_user_t_user_domain_user_domain_id",
                    column: x => x.user_domain_id,
                    principalTable: "t_user_domain",
                    principalColumn: "user_domain_id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_t_user_created_date",
            table: "t_user",
            column: "created_date");

        migrationBuilder.CreateIndex(
            name: "IX_t_user_user_domain_id",
            table: "t_user",
            column: "user_domain_id");

        migrationBuilder.CreateIndex(
            name: "IX_t_user_user_domain_id_user_name",
            table: "t_user",
            columns: new[] { "user_domain_id", "user_name" },
            unique: true,
            filter: "[user_domain_id] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_t_user_user_name",
            table: "t_user",
            column: "user_name");

        migrationBuilder.CreateIndex(
            name: "IX_t_user_domain_domain_name",
            table: "t_user_domain",
            column: "domain_name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "t_user");

        migrationBuilder.DropTable(
            name: "t_user_domain");
    }
}
