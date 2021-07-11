using Microsoft.EntityFrameworkCore.Migrations;

namespace HApi.Migrations
{
    public partial class ConnectionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Computers_ComputerId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_HDDs_Computers_ComputerId",
                table: "HDDs");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkCards_Computers_ComputerId",
                table: "NetworkCards");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Computers_ComputerId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_RAMs_ComputerId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_NetworkCards_ComputerId",
                table: "NetworkCards");

            migrationBuilder.DropIndex(
                name: "IX_HDDs_ComputerId",
                table: "HDDs");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_ComputerId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_ComputerId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "NetworkCards");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "HDDs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "CPUs");

            migrationBuilder.CreateTable(
                name: "ComputerCPU",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CPUId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerCPU", x => new { x.ComputerId, x.CPUId });
                    table.ForeignKey(
                        name: "FK_ComputerCPU_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerCPU_CPUs_CPUId",
                        column: x => x.CPUId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerGPU",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GPUId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerGPU", x => new { x.ComputerId, x.GPUId });
                    table.ForeignKey(
                        name: "FK_ComputerGPU_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerGPU_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerHDD",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    HDDId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerHDD", x => new { x.ComputerId, x.HDDId });
                    table.ForeignKey(
                        name: "FK_ComputerHDD_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerHDD_HDDs_HDDId",
                        column: x => x.HDDId,
                        principalTable: "HDDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerNetworkCard",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    NetworkCardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerNetworkCard", x => new { x.ComputerId, x.NetworkCardId });
                    table.ForeignKey(
                        name: "FK_ComputerNetworkCard_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerNetworkCard_NetworkCards_NetworkCardId",
                        column: x => x.NetworkCardId,
                        principalTable: "NetworkCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerRAM",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RAMId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerRAM", x => new { x.ComputerId, x.RAMId });
                    table.ForeignKey(
                        name: "FK_ComputerRAM_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerRAM_RAMs_RAMId",
                        column: x => x.RAMId,
                        principalTable: "RAMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerCPU_CPUId",
                table: "ComputerCPU",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerGPU_GPUId",
                table: "ComputerGPU",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerHDD_HDDId",
                table: "ComputerHDD",
                column: "HDDId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerNetworkCard_NetworkCardId",
                table: "ComputerNetworkCard",
                column: "NetworkCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerRAM_RAMId",
                table: "ComputerRAM",
                column: "RAMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerCPU");

            migrationBuilder.DropTable(
                name: "ComputerGPU");

            migrationBuilder.DropTable(
                name: "ComputerHDD");

            migrationBuilder.DropTable(
                name: "ComputerNetworkCard");

            migrationBuilder.DropTable(
                name: "ComputerRAM");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "RAMs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "NetworkCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "HDDs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "GPUs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "CPUs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_ComputerId",
                table: "RAMs",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkCards_ComputerId",
                table: "NetworkCards",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_ComputerId",
                table: "HDDs",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ComputerId",
                table: "GPUs",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ComputerId",
                table: "CPUs",
                column: "ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Computers_ComputerId",
                table: "CPUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDDs_Computers_ComputerId",
                table: "HDDs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkCards_Computers_ComputerId",
                table: "NetworkCards",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Computers_ComputerId",
                table: "RAMs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
