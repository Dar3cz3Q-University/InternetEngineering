using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuAsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Menus",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuId",
                table: "Menus",
                column: "MenuId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_MenuId",
                table: "Menus",
                column: "MenuId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_MenuId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Restaurants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menus",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menus",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}