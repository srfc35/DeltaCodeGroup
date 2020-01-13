using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
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

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        #endregion

        #region Constructors

        public Seller()
        {
                
        }
        public Seller(string lastname, string firstname, int phone, string login, string password) : base(lastname, firstname, phone)
        {
            Login = login;
            this.password = password;
        }
        #endregion
    }
}


