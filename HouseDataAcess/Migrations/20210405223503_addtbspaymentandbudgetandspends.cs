using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseDataAcess.Migrations
{
    public partial class addtbspaymentandbudgetandspends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Budget_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Montly_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Budget_Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Ms",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Ms", x => x.P_Id);
                });

            migrationBuilder.CreateTable(
                name: "Spends",
                columns: table => new
                {
                    Spend_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    Spend_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spend_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spends", x => x.Spend_Id);
                    table.ForeignKey(
                        name: "FK_Spends_Payment_Ms_P_Id",
                        column: x => x.P_Id,
                        principalTable: "Payment_Ms",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spends_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_User_Id",
                table: "Budgets",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Spends_P_Id",
                table: "Spends",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Spends_User_Id",
                table: "Spends",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Spends");

            migrationBuilder.DropTable(
                name: "Payment_Ms");
        }
    }
}
