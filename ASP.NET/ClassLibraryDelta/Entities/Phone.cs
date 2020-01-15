using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    [Table("Phone")]
    public class Phone:Product
    {
        #region Attribut
        private string os;

       
       
        public string Os
        {
            get { return os; }
            set { os = value; }
        }

        #endregion
        #region Constructor
        public Phone (int productID, string nameProduct, string brand, int size,
           float unitPriceHT, float vatRate, float discount, float weight,
           string color, string os) : base(productID, nameProduct, brand, size,
                         unitPriceHT, vatRate, discount, weight, color)
        {
            this.os = os;
        }

        public Phone()
        {
        }
        #endregion
        #region Method
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}
