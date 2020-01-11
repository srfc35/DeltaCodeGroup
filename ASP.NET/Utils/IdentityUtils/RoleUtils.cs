using DeltaCode.Models;
using DeltaCode.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaCode.Utils.IdentityUtils
{
    public static class RoleUtils
    {
        public static IdentityRole CreateOrGetRole(string roleName)
        {
            using (var ctx = new SecurityDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                IdentityRole result = null;

                if (!roleManager.RoleExists(roleName))
                {
                    result = new IdentityRole();
                    result.Name = roleName;
                    roleManager.Create(result);
                }

                return result ?? roleManager.FindByName(roleName);
            }
        }

        public static List<IdentityRole> GetRoles()
        {
            using (var ctx = new SecurityDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

                return roleManager.Roles.ToList();
            }
        }

        public static void AssignRoleToUser(IdentityRole role, MyIdentityUser user)
        {
            using (var ctx = new SecurityDbContext())
            {
                var userManager = new UserManager<MyIdentityUser>(new UserStore<MyIdentityUser>(ctx));

                userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}