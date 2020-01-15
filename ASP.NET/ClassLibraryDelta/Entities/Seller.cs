using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    [Table("Seller")]
    public class Seller : Person
    {
        #region Attributes
       
        
        private float sellerAccount;


        #endregion
        #region Properties

         
        [Required]
        public float SellerAccount
        {
            get { return sellerAccount; }
            set { sellerAccount = value; }
        }

        #endregion

        #region Constructors

        public Seller()
        {
                
        }
        public Seller(string lastname, string firstname, int phone) : base(lastname, firstname, phone)
        {

        }
        #endregion
    }
}


