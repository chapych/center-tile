using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataSuggesting.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSuggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email_Value = table.Column<string>(type: "text", nullable: true),
                    Comment_Text = table.Column<string>(type: "text", nullable: true),
                    Data_Material_Name = table.Column<string>(type: "text", nullable: true),
                    Data_Material_Id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSuggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    DataSuggestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => new { x.DataSuggestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_Coordinate_DataSuggestions_DataSuggestionId",
                        column: x => x.DataSuggestionId,
                        principalTable: "DataSuggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinate");

            migrationBuilder.DropTable(
                name: "DataSuggestions");
        }
    }
}
