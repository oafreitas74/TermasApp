using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermasApp.Migrations
{
    public partial class Final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "TipoTratamento");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "TipoConsulta");

            migrationBuilder.DropColumn(
                name: "IdTerma",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "IdTerma",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "IdTerma",
                table: "Aquista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "TipoTratamento",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "TipoConsulta",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTerma",
                table: "Funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Equipamento",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTerma",
                table: "Equipamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTerma",
                table: "Aquista",
                type: "int",
                nullable: true);
        }
    }
}
