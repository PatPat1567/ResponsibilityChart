using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResponsibilityChart.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildResponsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekId = table.Column<DateTime>(nullable: false),
                    ResponsibilityId = table.Column<int>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    WeekDay = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildResponsibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildResponsibilities_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildResponsibilities_Responsibilities_ResponsibilityId",
                        column: x => x.ResponsibilityId,
                        principalTable: "Responsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildResponsibilities_ChildId",
                table: "ChildResponsibilities",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildResponsibilities_ResponsibilityId",
                table: "ChildResponsibilities",
                column: "ResponsibilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildResponsibilities");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Responsibilities");
        }
    }
}
