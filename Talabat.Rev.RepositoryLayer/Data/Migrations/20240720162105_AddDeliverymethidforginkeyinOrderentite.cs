using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Rev.RepositoryLayer.Data.Migrations
{
    public partial class AddDeliverymethidforginkeyinOrderentite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_deliveryMethodId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "deliveryMethodId",
                table: "Orders",
                newName: "DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_deliveryMethodId",
                table: "Orders",
                newName: "IX_Orders_DeliveryMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DeliveryMethodId",
                table: "Orders",
                newName: "deliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                newName: "IX_Orders_deliveryMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_deliveryMethodId",
                table: "Orders",
                column: "deliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
