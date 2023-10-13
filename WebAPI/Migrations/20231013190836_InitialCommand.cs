using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    CommandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.CommandId);
                    table.ForeignKey(
                        name: "FK_Commands_Commands_CommandId1",
                        column: x => x.CommandId1,
                        principalTable: "Commands",
                        principalColumn: "CommandId");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CommandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "CommandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "CommandId", "City", "CommandId1", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("1ac59c05-7f72-45f5-bb5a-d2006998d3e7"), "Saransk", null, "Russia", "Mordovia" },
                    { new Guid("d960d5e1-a23e-4052-8d41-2cd31c6a9bda"), "Moscow", null, "Russia", "Amkal" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "CommandId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("92674f7a-31f0-4a51-9331-74e82ab980c1"), 25, new Guid("1ac59c05-7f72-45f5-bb5a-d2006998d3e7"), "Andrey Zubanov", "Goalkeeper" },
                    { new Guid("a68fcbca-7f58-45e6-a1f9-aea8d263764e"), 20, new Guid("1ac59c05-7f72-45f5-bb5a-d2006998d3e7"), "Nikita Shirmankin", "Center forward" },
                    { new Guid("c53068cb-27ab-4f3f-832e-b93f5f04e263"), 19, new Guid("d960d5e1-a23e-4052-8d41-2cd31c6a9bda"), "Denis Ivanov", "Halfback" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_CommandId1",
                table: "Commands",
                column: "CommandId1");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CommandId",
                table: "Players",
                column: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
