using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TantaJudge.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problemas",
                columns: table => new
                {
                    ProblemaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Tag = table.Column<string>(type: "TEXT", nullable: true),
                    Dificultad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemas", x => x.ProblemaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    ROL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    ProblemaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Problemas_ProblemaId",
                        column: x => x.ProblemaId,
                        principalTable: "Problemas",
                        principalColumn: "ProblemaId");
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    EnvioId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreDelProblema = table.Column<string>(type: "TEXT", nullable: true),
                    Veredicto = table.Column<string>(type: "TEXT", nullable: true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    FechaDeEnvio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Lenguaje = table.Column<int>(type: "INTEGER", nullable: false),
                    ProblemaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.EnvioId);
                    table.ForeignKey(
                        name: "FK_Envios_Problemas_ProblemaId",
                        column: x => x.ProblemaId,
                        principalTable: "Problemas",
                        principalColumn: "ProblemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ProblemaId",
                table: "Comentarios",
                column: "ProblemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ProblemaId",
                table: "Envios",
                column: "ProblemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_UsuarioId",
                table: "Envios",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Problemas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
