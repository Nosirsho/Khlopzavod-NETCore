using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KlopZavod.Migrations
{
    public partial class changePKvitanciyaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assoc",
                columns: table => new
                {
                    AssocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SocrName = table.Column<string>(nullable: true),
                    Jamoat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assoc", x => x.AssocID);
                });

            migrationBuilder.CreateTable(
                name: "Bunt",
                columns: table => new
                {
                    BuntID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bunt", x => x.BuntID);
                });

            migrationBuilder.CreateTable(
                name: "Rayon",
                columns: table => new
                {
                    RayonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rayon", x => x.RayonID);
                });

            migrationBuilder.CreateTable(
                name: "Semena",
                columns: table => new
                {
                    SemenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semena", x => x.SemenaID);
                });

            migrationBuilder.CreateTable(
                name: "Khojagi",
                columns: table => new
                {
                    KhojagiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    RMA = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Ga = table.Column<int>(nullable: false),
                    AssocID = table.Column<int>(nullable: true),
                    RayonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khojagi", x => x.KhojagiID);
                    table.ForeignKey(
                        name: "FK_Khojagi_Assoc_AssocID",
                        column: x => x.AssocID,
                        principalTable: "Assoc",
                        principalColumn: "AssocID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Khojagi_Rayon_RayonID",
                        column: x => x.RayonID,
                        principalTable: "Rayon",
                        principalColumn: "RayonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partiya",
                columns: table => new
                {
                    PartiyaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomerPart = table.Column<string>(nullable: true),
                    BuntID = table.Column<int>(nullable: false),
                    SemenaID = table.Column<int>(nullable: false),
                    Vid = table.Column<int>(nullable: false),
                    Sort = table.Column<byte>(nullable: false),
                    Sbor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partiya", x => x.PartiyaID);
                    table.ForeignKey(
                        name: "FK_Partiya_Bunt_BuntID",
                        column: x => x.BuntID,
                        principalTable: "Bunt",
                        principalColumn: "BuntID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partiya_Semena_SemenaID",
                        column: x => x.SemenaID,
                        principalTable: "Semena",
                        principalColumn: "SemenaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PKvitanciya",
                columns: table => new
                {
                    PKvitanciyaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomerPK = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    NomerNakl = table.Column<int>(nullable: false),
                    KhojagiID = table.Column<int>(nullable: false),
                    PartiyaID = table.Column<int>(nullable: false),
                    FizVes = table.Column<int>(nullable: false),
                    Zasor = table.Column<double>(nullable: false),
                    Vlagn = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKvitanciya", x => x.PKvitanciyaID);
                    table.ForeignKey(
                        name: "FK_PKvitanciya_Khojagi_KhojagiID",
                        column: x => x.KhojagiID,
                        principalTable: "Khojagi",
                        principalColumn: "KhojagiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PKvitanciya_Partiya_PartiyaID",
                        column: x => x.PartiyaID,
                        principalTable: "Partiya",
                        principalColumn: "PartiyaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khojagi_AssocID",
                table: "Khojagi",
                column: "AssocID");

            migrationBuilder.CreateIndex(
                name: "IX_Khojagi_RayonID",
                table: "Khojagi",
                column: "RayonID");

            migrationBuilder.CreateIndex(
                name: "IX_Partiya_BuntID",
                table: "Partiya",
                column: "BuntID");

            migrationBuilder.CreateIndex(
                name: "IX_Partiya_SemenaID",
                table: "Partiya",
                column: "SemenaID");

            migrationBuilder.CreateIndex(
                name: "IX_PKvitanciya_KhojagiID",
                table: "PKvitanciya",
                column: "KhojagiID");

            migrationBuilder.CreateIndex(
                name: "IX_PKvitanciya_PartiyaID",
                table: "PKvitanciya",
                column: "PartiyaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PKvitanciya");

            migrationBuilder.DropTable(
                name: "Khojagi");

            migrationBuilder.DropTable(
                name: "Partiya");

            migrationBuilder.DropTable(
                name: "Assoc");

            migrationBuilder.DropTable(
                name: "Rayon");

            migrationBuilder.DropTable(
                name: "Bunt");

            migrationBuilder.DropTable(
                name: "Semena");
        }
    }
}
