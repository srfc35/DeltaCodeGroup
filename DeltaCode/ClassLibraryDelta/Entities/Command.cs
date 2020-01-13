using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    [Table("Command")]
    public class Command
    {
        #region Attributs
        private int commandId;
        private DateTime dateCommand;
        private Client client;
        private Seller seller;
        #endregion

        #region Properties
        public int CommandID
        {
            get { return commandId; }
            set { commandId = value; }
        }
        [Column(TypeName = "datetime2")]

        public DateTime DateCommand
        {
            get { return dateCommand; }
            set { dateCommand = value; }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public Seller Seller
        {
            get { return seller; }
            set { seller = value; }
        }
        #endregion

        #region Constructors
        public Command()
        {

        }
        #endregion
    }

}

