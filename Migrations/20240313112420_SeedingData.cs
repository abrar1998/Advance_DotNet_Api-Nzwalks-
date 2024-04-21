using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZZwalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficultes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("75636fd6-b9ef-4733-b825-c86b113ff0f9"), "Hard" },
                    { new Guid("db804d2d-4ee6-4efc-947c-a8d0897c81f6"), "Medium" },
                    { new Guid("e3b6568a-1119-4e30-bc8c-f7a4913818ec"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUlr" },
                values: new object[,]
                {
                    { new Guid("5581f6b5-5324-496c-ac24-eea19275ad4d"), "NL", "North Land", "null" },
                    { new Guid("7a26d1ff-e379-4df3-9e01-1c4180fcdc39"), "BOP", "Bay of Plenty", "null" },
                    { new Guid("8e61003c-75a9-41dc-a8fd-fe63e87ebef8"), "AKL", "AuckLand", "https://www.bing.com/images/search?view=detailV2&ccid=UkG89vab&id=371078079B0C47E89D79B33CEAB95F88E61D1DB6&thid=OIP.UkG89vab4fcyUBAA5VjC6gHaFP&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.5241bcf6f69be1f732501000e558c2ea%3frik%3dth0d5ohfueo8sw%26riu%3dhttp%253a%252f%252fwallpapercave.com%252fwp%252fsoSaTJM.jpg%26ehk%3dnUl6MV1yd74%252fP%252fWBLP%252b5aM%252fDbbp7HkpX1PCLIEK%252feVo%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1700&expw=2400&q=nature+pics&simid=608044958947812527&FORM=IRPRST&ck=BA5A9B2E1D264AF298F494ADAEAB30BF&selectedIndex=0&itb=0&idpp=overlayview&ajaxhist=0&ajaxserp=0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficultes",
                keyColumn: "Id",
                keyValue: new Guid("75636fd6-b9ef-4733-b825-c86b113ff0f9"));

            migrationBuilder.DeleteData(
                table: "Difficultes",
                keyColumn: "Id",
                keyValue: new Guid("db804d2d-4ee6-4efc-947c-a8d0897c81f6"));

            migrationBuilder.DeleteData(
                table: "Difficultes",
                keyColumn: "Id",
                keyValue: new Guid("e3b6568a-1119-4e30-bc8c-f7a4913818ec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5581f6b5-5324-496c-ac24-eea19275ad4d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7a26d1ff-e379-4df3-9e01-1c4180fcdc39"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8e61003c-75a9-41dc-a8fd-fe63e87ebef8"));
        }
    }
}
