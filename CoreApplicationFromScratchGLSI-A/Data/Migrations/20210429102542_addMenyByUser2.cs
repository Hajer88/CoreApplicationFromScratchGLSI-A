using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApplicationFromScratchGLSI_A.Data.Migrations
{
    public partial class addMenyByUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menus");
        }
    }
}
