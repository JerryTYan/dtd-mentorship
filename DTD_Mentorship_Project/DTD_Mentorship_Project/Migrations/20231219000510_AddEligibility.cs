using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTD_Mentorship_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddEligibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "TermsofServiceCheckbox",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Area",
                newName: "Areas");

            migrationBuilder.RenameColumn(
                name: "Identity_Name",
                table: "Identity",
                newName: "IdentityName");

            migrationBuilder.RenameColumn(
                name: "Zip_Code",
                table: "Address",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street_Address",
                table: "Address",
                newName: "StreetAddress");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaName",
                table: "Areas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Areas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areas",
                table: "Areas",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Areas",
                table: "Areas");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "IdentityName",
                table: "Identity",
                newName: "Identity_Name");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Address",
                newName: "Zip_Code");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Address",
                newName: "Street_Address");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TermsofServiceCheckbox",
                table: "User",
                type: "bit",
                maxLength: 200,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "AreaName",
                table: "Area",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Area",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "AreaId");
        }
    }
}
