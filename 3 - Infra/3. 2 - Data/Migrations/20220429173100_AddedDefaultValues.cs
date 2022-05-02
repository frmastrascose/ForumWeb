using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Dal.Migrations
{
    public partial class AddedDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Views",
                table: "Posts",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Views",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
