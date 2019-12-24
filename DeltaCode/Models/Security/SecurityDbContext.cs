using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DeltaCode.Models.Security;
using DeltaCode.Utils.IdentityUtils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeltaCode.Models.Security
{
    public class SecurityDbContext : IdentityDbContext<MyIdentityUser>
    {
        public SecurityDbContext()
            : base("DefaultSecurityConnection", throwIfV1Schema: false)
        {
            if (this.Database.CreateIfNotExists())
            {
                IdentityRole userRole = RoleUtils.CreateOrGetRole("User");
                IdentityRole adminRole = RoleUtils.CreateOrGetRole("Admin");

                UserManager<MyIdentityUser> userManager = new MyIdentityUserManager(new UserStore<MyIdentityUser>(this));
                MyIdentityUser admin = new MyIdentityUser() { UserName = "admin", Email = "admin@mysite.com", Login = "admin" };
                var result = userManager.Create(admin, "Admin!123");
                if (!result.Succeeded)
                {
                    this.Database.Delete();
                    throw new System.Exception("database insert fail");
                }
                RoleUtils.AssignRoleToUser(adminRole, admin);
            }
        }

        public static SecurityDbContext Create()
        {
            return new SecurityDbContext();
        }
    }
}