using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ICSApp.ActivityService.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    IdSection = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.IdSection);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IdActivity = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    DateOpen = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdIncident = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false),
                    IdSection = table.Column<int>(nullable: false),
                    UsuarioInsercao = table.Column<string>(nullable: true),
                    DataHoraInsercao = table.Column<DateTime>(nullable: false),
                    UsuarioUltimaAtualizacao = table.Column<string>(nullable: true),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IdActivity);
                    table.ForeignKey(
                        name: "FK_Incident_Section_IdSection",
                        column: x => x.IdSection,
                        principalTable: "Section",
                        principalColumn: "IdSection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IdSection",
                table: "Incident",
                column: "IdSection");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IdStatus",
                table: "Incident",
                column: "IdStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
