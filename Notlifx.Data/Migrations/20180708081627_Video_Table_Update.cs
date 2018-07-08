using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Notlifx.Data.Migrations
{
    public partial class Video_Table_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoDescription",
                table: "Video",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "VideoImage",
                table: "Video",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoDescription",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "VideoImage",
                table: "Video");
        }
    }
}
