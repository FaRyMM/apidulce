using Microsoft.EntityFrameworkCore.Migrations;

namespace APIDulce.Migrations
{
    public partial class CategoriaCorregido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcategoria",
                table: "Categorias");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.AddColumn<bool>(
                name: "Subcategoria",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
