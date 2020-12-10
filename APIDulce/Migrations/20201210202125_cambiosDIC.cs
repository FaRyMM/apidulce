using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIDulce.Migrations
{
    public partial class cambiosDIC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_EstadosVentas_EstadoId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "TotalIpsi",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ConfigPrecios");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Ventas",
                newName: "EstadoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ventas",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_EstadoId",
                table: "Ventas",
                newName: "IX_Ventas_EstadoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proveedores",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EstadosVentas",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetalleVenta",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConfigPrecios",
                newName: "ID");

            migrationBuilder.AddColumn<double>(
                name: "Envio",
                table: "Ventas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Ventas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TotalImpuesto",
                table: "Ventas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Impuestos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "EstadosVentas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImpuestoId",
                table: "ConfigPrecios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPrecios_ImpuestoId",
                table: "ConfigPrecios",
                column: "ImpuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigPrecios_Impuestos_ImpuestoId",
                table: "ConfigPrecios",
                column: "ImpuestoId",
                principalTable: "Impuestos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_EstadosVentas_EstadoID",
                table: "Ventas",
                column: "EstadoID",
                principalTable: "EstadosVentas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigPrecios_Impuestos_ImpuestoId",
                table: "ConfigPrecios");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_EstadosVentas_EstadoID",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_ConfigPrecios_ImpuestoId",
                table: "ConfigPrecios");

            migrationBuilder.DropColumn(
                name: "Envio",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TotalImpuesto",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImpuestoId",
                table: "ConfigPrecios");

            migrationBuilder.RenameColumn(
                name: "EstadoID",
                table: "Ventas",
                newName: "EstadoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ventas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_EstadoID",
                table: "Ventas",
                newName: "IX_Ventas_EstadoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Proveedores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Productos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "EstadosVentas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DetalleVenta",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ConfigPrecios",
                newName: "Id");

            migrationBuilder.AddColumn<double>(
                name: "TotalIpsi",
                table: "Ventas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Impuestos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "EstadosVentas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ConfigPrecios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_EstadosVentas_EstadoId",
                table: "Ventas",
                column: "EstadoId",
                principalTable: "EstadosVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
