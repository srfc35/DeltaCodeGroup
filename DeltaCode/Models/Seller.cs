using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCode.Models
{
    public class Seller : Person
    {
        #region Attributes

        private float sellerAccount;
        private string login;
        private string password;

        #endregion

        #region Properties

        [Required]
        public float SellerAccount
        {
            get { return sellerAccount; }
            set { sellerAccount = value; }
        }

        [Required]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [Required]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Constructors

        public Seller()
        {

        }
        public Seller(string lastname, string firstname, int phone, string login, string password) : base(lastname, firstname, phone)
        {
            this.login = login;
            this.password = password;
        }
        #endregion
    }
}


