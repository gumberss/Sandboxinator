using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    US_Gross = table.Column<long>(nullable: true),
                    Worldwide_Gross = table.Column<long>(nullable: true),
                    US_DVD_Sales = table.Column<string>(nullable: true),
                    Production_Budget = table.Column<long>(nullable: true),
                    Release_Date = table.Column<DateTime>(nullable: false),
                    MPAA_Rating = table.Column<string>(nullable: true),
                    Running_Time_min = table.Column<long>(nullable: true),
                    Distributor = table.Column<string>(nullable: true),
                    Major_Genre = table.Column<string>(nullable: true),
                    Creative_Type = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Rotten_Tomatoes_Rating = table.Column<int>(nullable: true),
                    IMDB_Rating = table.Column<float>(nullable: true),
                    IMDB_Votes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
