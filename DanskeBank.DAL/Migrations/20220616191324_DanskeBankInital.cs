using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanskeBank.DAL.Migrations
{
    public partial class DanskeBankInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleSets",
                columns: table => new
                {
                    RuleSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxRule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSets", x => x.RuleSetId);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleSetId = table.Column<int>(type: "int", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,1)", precision: 18, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleId);
                    table.ForeignKey(
                        name: "FK_Rules_RuleSets_RuleSetId",
                        column: x => x.RuleSetId,
                        principalTable: "RuleSets",
                        principalColumn: "RuleSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RuleSets",
                columns: new[] { "RuleSetId", "Municipality", "TaxRule" },
                values: new object[] { 1, "Kaunas", 1 });

            migrationBuilder.InsertData(
                table: "RuleSets",
                columns: new[] { "RuleSetId", "Municipality", "TaxRule" },
                values: new object[] { 2, "Vilnius", 2 });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "RuleId", "FromDate", "RuleSetId", "Schedule", "Tax", "ToDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Year", 0.3m, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Month", 0.2m, new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Week", 0.1m, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Year", 0.2m, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Month", 0.4m, new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Day", 0.1m, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Day", 0.1m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_RuleSetId",
                table: "Rules",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_Schedule",
                table: "Rules",
                column: "Schedule");

            migrationBuilder.CreateIndex(
                name: "IX_RuleSets_Municipality",
                table: "RuleSets",
                column: "Municipality");

            migrationBuilder.CreateIndex(
                name: "IX_RuleSets_Municipality_TaxRule",
                table: "RuleSets",
                columns: new[] { "Municipality", "TaxRule" },
                unique: true,
                filter: "[Municipality] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "RuleSets");
        }
    }
}
