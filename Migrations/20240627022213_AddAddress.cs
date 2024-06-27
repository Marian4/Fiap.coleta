using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.coleta.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    street = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    neighborhood = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    number = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    complement = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    city = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    state = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "residents",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    address_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residents", x => x.id);
                    table.ForeignKey(
                        name: "FK_residents_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_residents_address_id",
                table: "residents",
                column: "address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "residents");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
