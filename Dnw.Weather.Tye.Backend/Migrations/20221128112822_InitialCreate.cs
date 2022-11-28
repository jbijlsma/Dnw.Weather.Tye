using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnw.Weather.Tye.Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 29, 11, 28, 22, 60, DateTimeKind.Utc).AddTicks(5010), "Warm", 37 },
                    { 2, new DateTime(2022, 11, 30, 11, 28, 22, 60, DateTimeKind.Utc).AddTicks(5030), "Sweltering", -5 },
                    { 3, new DateTime(2022, 12, 1, 11, 28, 22, 60, DateTimeKind.Utc).AddTicks(5030), "Balmy", -2 },
                    { 4, new DateTime(2022, 12, 2, 11, 28, 22, 60, DateTimeKind.Utc).AddTicks(5040), "Freezing", 0 },
                    { 5, new DateTime(2022, 12, 3, 11, 28, 22, 60, DateTimeKind.Utc).AddTicks(5040), "Mild", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
