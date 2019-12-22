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
        private List<Command> listcommand;

        #endregion

        #region Properties

        [Required]
        public float SellerAccount
        {
            get { return sellerAccount; }
            set { sellerAccount = value; }
        }

        [StringLength(30)]
        [Required]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [StringLength(30)]
        [Required]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Required]
        public List<Command> ListCommand
        {
            get { return listcommand; }
            set { listcommand = value; }
        }

        #endregion

        #region Constructors

        public Seller()
        {
            this.listcommand = new List<Command>();
        }
        public Seller(string lastname, string firstname, int phone, string login, string password) : base(lastname, firstname, phone)
        {
            this.login = login;
            this.password = password;
            this.listcommand = new List<Command>();
        }
        #endregion
    }
}


