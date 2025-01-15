using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.Migrations
{
    /// <inheritdoc />
    public partial class RecordShopMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Records");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_ArtistId",
                table: "Records",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Records_ArtistId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Records");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
