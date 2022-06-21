using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reciever.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crc32 = table.Column<long>(nullable: false),
                    CompressedLength = table.Column<int>(nullable: false),
                    ExternalAttributes = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    LastWriteTime = table.Column<DateTime>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archives");
        }
    }
}
