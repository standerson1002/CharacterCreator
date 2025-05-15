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
                    { "152558a1-7dfd-4f8a-ac27-a0694e6ff19e", "Admin", "ADMIN", DateTime.Now.ToString() }, 
                    { "4fd9021b-b11b-49d4-9962-2c95b05c0c9e", "User", "USER", DateTime.Now.ToString() },
                    { Guid.NewGuid().ToString(), "No Access", "NO ACCESS", DateTime.Now.ToString() }
                });




            //List<string> securityStamps = new List<string>();
            //securityStamps.Add("QEKKRHRVBUQ3DKEKMTGBYH4LNEHAAWCX");
            //securityStamps.Add("OXAR7BW44KS3GCZN4KGCL47UYYRCWNPS");
            //securityStamps.Add("OPOPXAR7BW44KS3G4KGCL47UYYRCWNPS");
            //securityStamps.Add("REKKQHRVDUQ3DKLKMTGBYH4LNEHAAPTD");

            List<DataDomain.User> users = userManager.SelectAllUsers();

            foreach (DataDomain.User user in users)
            {
                string guid = Guid.NewGuid().ToString();
                migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail",
                    "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "AccessFailedCount",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled"
                    },
                values: new object[,]
                {
                    { guid, user.Username, user.Email.ToUpper(), user.Email, user.Email.ToUpper(), true,
                        new PasswordHasher<IdentityUser>().HashPassword(null, "P@ssw0rd"),
                        Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 0, false, false, true
                    }
                });

                //securityStamps.RemoveAt(0);

                migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { guid, "4fd9021b-b11b-49d4-9962-2c95b05c0c9e" }
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
                    { "4f4af597-4b7a-463b-8e43-bd18c8eee952", "admin", "ADMIN@COMPANY.COM", 
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


            userManager.CreateNewAccount("admin", "admin@company.com", "P@ssw0rd");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
