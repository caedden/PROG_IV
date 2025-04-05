using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacaoIV.ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUnificada_1_0_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NOTAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Aluno = table.Column<string>(type: "char(100)", nullable: false),
                    Disciplina = table.Column<string>(type: "longtext", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTAS");
        }
    }
}
