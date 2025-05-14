using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCharacterCreator.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            LogicLayer.UserManager userManager = new LogicLayer.UserManager();

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { "152558a1-7dfd-4f8a-ac27-a0694e6ff19e", "Admin", "ADMIN", DateTime.Now.ToString() }, //152558a1-7dfd-4f8a-ac27-a0694e6ff19e
                    { Guid.NewGuid().ToString(), "User", "USER", DateTime.Now.ToString() },
                    { Guid.NewGuid().ToString(), "No Access", "NO ACCESS", DateTime.Now.ToString() }
                });

            List<DataDomain.User> users = userManager.SelectAllUsers();

            foreach (DataDomain.User user in users)
            {
                migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "Email",
                    "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "AccessFailedCount",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled"
                    },
                values: new object[,]
                {
                    { user.Username, user.Username, user.Email, true,
                        new PasswordHasher<IdentityUser>().HashPassword(null, "newuser"),
                        "BIXSQ7WWCLLC6KADKKKLLOYLY672DD7T", DateTime.Now.ToString(), 0, false, false, true
                    }
                });
            }





            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail",
                    "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "AccessFailedCount",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled"
                    },
                values: new object[,]
                {
                    { "4f4af597-4b7a-463b-8e43-bd18c8eee952", "admin", "ADMIN@COMPANY.COM", //4f4af597-4b7a-463b-8e43-bd18c8eee952
                        "admin@company.com", "ADMIN@COMPANY.COM", true,
                        new PasswordHasher<IdentityUser>().HashPassword(null, "P@ssw0rd"),
                        "BIXSQ7WWCLLC6KADKKKLLOYLY672DD7T", DateTime.Now.ToString(), 0, false, false, true
                    }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "4f4af597-4b7a-463b-8e43-bd18c8eee952", "152558a1-7dfd-4f8a-ac27-a0694e6ff19e" }
                });

            //migrationBuilder.InsertData(
            //    table: "UserAccount",
            //    columns: new[] { "UserID", "Email", "PasswordHash" },
            //    values: new object[,]
            //    {
            //        { "admin@company.com", "admin@company.com", new PasswordHasher<IdentityUser>().HashPassword(null, "P@ssw0rd")}
            //    });

            userManager.CreateNewAccount("admin", "admin@company.com", "P@ssw0rd");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
