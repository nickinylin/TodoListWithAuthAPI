using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TodoWebAPI.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Lists_ListModelId",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "Elements");

            migrationBuilder.AlterColumn<int>(
                name: "ListModelId",
                table: "Elements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Lists_ListModelId",
                table: "Elements",
                column: "ListModelId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elements_Lists_ListModelId",
                table: "Elements");

            migrationBuilder.AlterColumn<int>(
                name: "ListModelId",
                table: "Elements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "Elements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Elements_Lists_ListModelId",
                table: "Elements",
                column: "ListModelId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
