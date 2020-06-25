using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Onawa_Deco.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Dni = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Seminarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Duracion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    TelefonoContacto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorSeminarios",
                columns: table => new
                {
                    ProfesorDni = table.Column<int>(nullable: false),
                    SeminarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorSeminarios", x => new { x.ProfesorDni, x.SeminarioId });
                    table.ForeignKey(
                        name: "FK_ProfesorSeminarios_Profesores_ProfesorDni",
                        column: x => x.ProfesorDni,
                        principalTable: "Profesores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorSeminarios_Seminarios_SeminarioId",
                        column: x => x.SeminarioId,
                        principalTable: "Seminarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocioSeminario",
                columns: table => new
                {
                    SocioId = table.Column<int>(nullable: false),
                    SeminarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioSeminario", x => new { x.SocioId, x.SeminarioId });
                    table.ForeignKey(
                        name: "FK_SocioSeminario_Seminarios_SeminarioId",
                        column: x => x.SeminarioId,
                        principalTable: "Seminarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioSeminario_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorSeminarios_SeminarioId",
                table: "ProfesorSeminarios",
                column: "SeminarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SocioSeminario_SeminarioId",
                table: "SocioSeminario",
                column: "SeminarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesorSeminarios");

            migrationBuilder.DropTable(
                name: "SocioSeminario");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Seminarios");

            migrationBuilder.DropTable(
                name: "Socios");
        }
    }
}
