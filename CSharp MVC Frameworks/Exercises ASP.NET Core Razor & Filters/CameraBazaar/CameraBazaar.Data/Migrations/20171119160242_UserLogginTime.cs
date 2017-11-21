using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CameraBazaar.Data.Migrations
{
    public partial class UserLogginTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "AspNetUsers");
        }
    }
}
