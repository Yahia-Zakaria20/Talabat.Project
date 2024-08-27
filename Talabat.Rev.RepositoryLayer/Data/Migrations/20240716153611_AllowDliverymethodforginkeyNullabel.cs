using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Rev.RepositoryLayer.Data.Migrations
{
    public partial class AllowDliverymethodforginkeyNullabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "deliveryMethodId",
                table: "Orders",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "deliveryMethodId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
