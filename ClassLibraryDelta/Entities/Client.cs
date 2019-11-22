using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    public class Client : Person
    {
        #region Attributs
       

       
        private float clientAccount;
        #endregion

        #region Properties
        
       
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

        }
        #endregion
    }
}
