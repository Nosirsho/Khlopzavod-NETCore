using Microsoft.EntityFrameworkCore.Migrations;

namespace KlopZavod.Migrations
{
    public partial class changePKvitanciyaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Zasor",
                table: "PKvitanciya",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Vlagn",
                table: "PKvitanciya",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Zasor",
                table: "PKvitanciya",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Vlagn",
                table: "PKvitanciya",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
