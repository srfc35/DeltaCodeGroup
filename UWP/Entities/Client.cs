using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Entities
{
    public class Client : Person
    {
        #region Attributes
        private List<Command> listcommand;
        private float clientAccount;
        #endregion

        #region Properties

        [OneToMany]
        public List<Command> ListCommand
        {
            get { return listcommand; }
            set { listcommand = value; }
        }

        [Required]
        public float ClientAccount
        {
            get { return clientAccount; }
            set { clientAccount = value; }
        }

        #endregion

        #region Constructors
        public Client()
        {
            this.listcommand = new List<Command>();
        }

        public Client(string lastname, string firstname, int phone, string email) : base(lastname, firstname, phone, email)
        {
            this.listcommand = new List<Command>();
        }
        #endregion
    }
}
