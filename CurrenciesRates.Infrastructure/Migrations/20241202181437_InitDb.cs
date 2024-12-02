using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrenciesRates.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrenciesRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "VARCHAR(3)", nullable: false),
                    Bid = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    Ask = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenciesRates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenciesRates");
        }
    }
}
