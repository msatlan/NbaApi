using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("2bd38c6e-8eca-476a-aebd-d0e02c1c2727"), new DateTime(2022, 5, 11, 12, 7, 10, 835, DateTimeKind.Utc).AddTicks(1566), null, "Center" },
                    { new Guid("6b2d65b9-ae72-4d34-a821-e399100635c9"), new DateTime(2022, 5, 11, 12, 7, 10, 835, DateTimeKind.Utc).AddTicks(1588), null, "Point Guard" },
                    { new Guid("7b6f89c2-c8e6-478f-a874-6b164c5ab834"), new DateTime(2022, 5, 11, 12, 7, 10, 835, DateTimeKind.Utc).AddTicks(1585), null, "Small Forward" },
                    { new Guid("a9bdc4fd-bd89-4d64-b673-a4bf99e9db34"), new DateTime(2022, 5, 11, 12, 7, 10, 835, DateTimeKind.Utc).AddTicks(1569), null, "Power Forward" },
                    { new Guid("f2da1ed1-d5ed-41ac-9254-e4bdaaa21c2e"), new DateTime(2022, 5, 11, 12, 7, 10, 835, DateTimeKind.Utc).AddTicks(1587), null, "Shooting Guard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
