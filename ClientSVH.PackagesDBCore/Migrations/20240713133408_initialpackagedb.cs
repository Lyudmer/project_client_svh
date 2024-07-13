using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientSVH.PackagesDBCore.Migrations
{
    /// <inheritdoc />
    public partial class initialpackagedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pkg_status_graph",
                columns: table => new
                {
                    oldst = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    newst = table.Column<int>(type: "integer", nullable: false),
                    maskbit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pkg_status_graph", x => x.oldst);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fullname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hidden = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pkg_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    runwf = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    mkres = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    oldst = table.Column<int>(type: "integer", nullable: false),
                    newst = table.Column<int>(type: "integer", nullable: false),
                    pid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pkg_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_pkg_status_pkg_status_graph_oldst",
                        column: x => x.oldst,
                        principalTable: "pkg_status_graph",
                        principalColumn: "oldst",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    pid = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.pid);
                    table.ForeignKey(
                        name: "FK_packages_pkg_status_pid",
                        column: x => x.pid,
                        principalTable: "pkg_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packages_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    did = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    docdate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 5, nullable: false),
                    modecode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    size_doc = table.Column<int>(type: "integer", nullable: false),
                    idmd5 = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    idsha256 = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    pid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.did);
                    table.ForeignKey(
                        name: "FK_documents_packages_did",
                        column: x => x.did,
                        principalTable: "packages",
                        principalColumn: "pid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_packages_user_id",
                table: "packages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pkg_status_oldst",
                table: "pkg_status",
                column: "oldst",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "pkg_status");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "pkg_status_graph");
        }
    }
}
