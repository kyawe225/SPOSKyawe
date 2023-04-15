using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPOS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class smallchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_OrderTableId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_OrderTableId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderTableId",
                table: "orderDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "orderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "orderDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderTableId",
                table: "orderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderTableId",
                table: "orderDetails",
                column: "OrderTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_OrderTableId",
                table: "orderDetails",
                column: "OrderTableId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
