using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login_Register.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    customers_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    realname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.customers_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_email",
                table: "UserAccounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_realname",
                table: "UserAccounts",
                column: "realname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_username",
                table: "UserAccounts",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
