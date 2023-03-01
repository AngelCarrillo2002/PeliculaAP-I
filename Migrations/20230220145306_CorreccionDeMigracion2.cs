using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculaAP_I.Migrations
{
    public partial class CorreccionDeMigracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categroias",
                table: "Categroias");

            migrationBuilder.RenameTable(
                name: "Categroias",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categroias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categroias",
                table: "Categroias",
                column: "Id");
        }
    }
}
