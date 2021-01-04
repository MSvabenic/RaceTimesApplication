using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTimesApplication.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Time",
                table: "UserTimes",
                type: "decimal(16,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "UserTimes",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "UserTimes");

            migrationBuilder.AlterColumn<double>(
                name: "Time",
                table: "UserTimes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)");
        }
    }
}
