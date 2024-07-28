using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientSVH.PackagesDBCore.Migrations
{
    /// <inheritdoc />
    public partial class initialpackagedb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packages_pkg_status_pid",
                table: "packages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_pkg_status_TempId",
                table: "pkg_status");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "pkg_status");

            migrationBuilder.AddColumn<Guid>(
                name: "docid",
                table: "documents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_packages_pkg_status_pid",
                table: "packages",
                column: "pid",
                principalTable: "pkg_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packages_pkg_status_pid",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "docid",
                table: "documents");

            migrationBuilder.AddColumn<long>(
                name: "TempId",
                table: "pkg_status",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_pkg_status_TempId",
                table: "pkg_status",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_packages_pkg_status_pid",
                table: "packages",
                column: "pid",
                principalTable: "pkg_status",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
