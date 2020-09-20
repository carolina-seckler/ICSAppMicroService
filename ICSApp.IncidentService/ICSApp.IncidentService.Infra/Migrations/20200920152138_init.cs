using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ICSApp.IncidentService.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    IdFunction = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.IdFunction);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IdIncident = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioInsercao = table.Column<string>(nullable: true),
                    DataHoraInsercao = table.Column<DateTime>(nullable: false),
                    UsuarioUltimaAtualizacao = table.Column<string>(nullable: true),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IdIncident);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    IdMember = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdIncident = table.Column<int>(nullable: false),
                    IdFunction = table.Column<int>(nullable: false),
                    IdSection = table.Column<int>(nullable: false),
                    IdUser = table.Column<byte[]>(nullable: false),
                    UsuarioInsercao = table.Column<string>(nullable: true),
                    DataHoraInsercao = table.Column<DateTime>(nullable: false),
                    UsuarioUltimaAtualizacao = table.Column<string>(nullable: true),
                    DataHoraUltimaAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.IdMember);
                    table.ForeignKey(
                        name: "FK_Member_Function_IdFunction",
                        column: x => x.IdFunction,
                        principalTable: "Function",
                        principalColumn: "IdFunction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Incident_IdIncident",
                        column: x => x.IdIncident,
                        principalTable: "Incident",
                        principalColumn: "IdIncident",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_IdFunction",
                table: "Member",
                column: "IdFunction");

            migrationBuilder.CreateIndex(
                name: "IX_Member_IdIncident",
                table: "Member",
                column: "IdIncident");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Incident");
        }
    }
}
