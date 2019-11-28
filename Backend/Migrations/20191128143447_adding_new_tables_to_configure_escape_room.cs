﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class adding_new_tables_to_configure_escape_room : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSequences",
                columns: table => new
                {
                    MacAddress = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSequences", x => x.MacAddress);
                });

            migrationBuilder.CreateTable(
                name: "AttemptDevices",
                columns: table => new
                {
                    AttemptId = table.Column<int>(nullable: false),
                    MacAddress = table.Column<string>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    FinshedAt = table.Column<DateTime>(nullable: false),
                    DeviceMacAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptDevices", x => new { x.AttemptId, x.MacAddress });
                    table.ForeignKey(
                        name: "FK_AttemptDevices_Attempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "Attempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptDevices_ConnectedDevices_DeviceMacAddress",
                        column: x => x.DeviceMacAddress,
                        principalTable: "ConnectedDevices",
                        principalColumn: "MacAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttemptDevices_DeviceMacAddress",
                table: "AttemptDevices",
                column: "DeviceMacAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttemptDevices");

            migrationBuilder.DropTable(
                name: "GameSequences");

            migrationBuilder.DropTable(
                name: "Attempts");
        }
    }
}
