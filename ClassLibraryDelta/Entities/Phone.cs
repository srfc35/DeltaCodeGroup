using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    public class Phone:Product
    {
        #region Attribut
        [Required]
        private string os;
        #endregion

        #region Properties
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

        public void UpdateOS(string os)
        {
            if (!os.Equals(""))
            {
                Os = os;
            }

            else
            {
                throw new Exception("L'OS spécifié n'est pas valide");
            }
        }

        #endregion
    }
}
