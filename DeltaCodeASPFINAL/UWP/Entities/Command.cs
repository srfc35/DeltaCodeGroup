﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Entities
{
    public class Command
    {
        #region Attributes
        private int commandId;
        private DateTime dateCommand;
        private Client client;
        private Seller seller;
        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommandID
        {
            get { return commandId; }
            set { commandId = value; }
        }

        [Range(typeof(DateTime), "01/01/2019", "01/01/2100")]
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

        public Command(Client client, Seller seller)
        {
            if (client != null && seller != null)
            {
                Client = client;
                Seller = seller;
                DateCommand = DateTime.Today;

            }
            else
            {
                throw new Exception("Client null ou Seller null");
            }
        }

        public Command()
        {

        }
        #endregion
    }

}

