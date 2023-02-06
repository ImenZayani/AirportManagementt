using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructures.Migrations
{
    public partial class fluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlace_PlaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlace",
                table: "MyPlace");

            migrationBuilder.RenameTable(
                name: "MyPlace",
                newName: "MyPlanes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "MyPlace");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlace",
                table: "MyPlace",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlace_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "MyPlace",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
