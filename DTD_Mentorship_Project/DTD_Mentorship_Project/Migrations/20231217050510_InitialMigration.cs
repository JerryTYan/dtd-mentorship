using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTD_Mentorship_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Identity_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OngoingMentorship = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdentityId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Availability = table.Column<DateTime>(type: "datetime", maxLength: 200, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FieldofWork = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedUserTypeId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TermsofServiceCheckbox = table.Column<bool>(type: "bit", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "Identity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Street_Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Zip_Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MentorMentee",
                columns: table => new
                {
                    MentorMenteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorId = table.Column<int>(type: "int", nullable: false),
                    MenteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorMentee", x => x.MentorMenteeId);
                    table.ForeignKey(
                        name: "FK_MentorMentee_Mentee",
                        column: x => x.MenteeId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_MentorMentee_Mentor",
                        column: x => x.MentorId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserArea",
                columns: table => new
                {
                    UserAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArea", x => x.UserAreaId);
                    table.ForeignKey(
                        name: "FK_UserArea_Area",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId");
                    table.ForeignKey(
                        name: "FK_UserArea_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorMentee_MenteeId",
                table: "MentorMentee",
                column: "MenteeId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorMentee_MentorId",
                table: "MentorMentee",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityId",
                table: "User",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArea_AreaId",
                table: "UserArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArea_UserId",
                table: "UserArea",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "MentorMentee");

            migrationBuilder.DropTable(
                name: "UserArea");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Identity");
        }
    }
}
