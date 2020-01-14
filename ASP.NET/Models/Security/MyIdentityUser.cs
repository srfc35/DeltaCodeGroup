using DeltaCode.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DeltaCode.Models.Security
{
    public enum Civility
    {
        Mr,
        Ms,
    }

    public class MyIdentityUser : IdentityUser
    {
        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private Civility civility;

        public Civility Civility
        {
            get { return civility; }
            set { civility = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyIdentityUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}