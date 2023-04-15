using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPOS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class inventorytableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTable_products_ProductId",
                table: "InventoryTable");

            migrationBuilder.DropForeignKey(
                name: "FK_productInventories_InventoryTable_InventoryId",
                table: "productInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTable",
                table: "InventoryTable");

            migrationBuilder.RenameTable(
                name: "InventoryTable",
                newName: "inventory");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTable_ProductId",
                table: "inventory",
                newName: "IX_inventory_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory",
                table: "inventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_ProductId",
                table: "inventory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productInventories_inventory_InventoryId",
                table: "productInventories",
                column: "InventoryId",
                principalTable: "inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_ProductId",
                table: "inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_productInventories_inventory_InventoryId",
                table: "productInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory",
                table: "inventory");

            migrationBuilder.RenameTable(
                name: "inventory",
                newName: "InventoryTable");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_ProductId",
                table: "InventoryTable",
                newName: "IX_InventoryTable_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTable",
                table: "InventoryTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTable_products_ProductId",
                table: "InventoryTable",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productInventories_InventoryTable_InventoryId",
                table: "productInventories",
                column: "InventoryId",
                principalTable: "InventoryTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
