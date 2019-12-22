using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCode.Models
{
    public class Phone : Product
    {
        #region Attributes
        private string os;
        #endregion

        #region Properties

        [StringLength(30)]
        [Required]
        public string Os
        {
            get { return os; }
            set { os = value; }
        }
        #endregion

        #region Constructor
        public Phone(int productID, string nameProduct, string brand, int size,
           float unitPriceHT, float vatRate, float discount, float weight,
           string color, string os) : base(productID, nameProduct, brand, size,
                         unitPriceHT, vatRate, discount, weight, color)
        {
            if (!os.Equals(""))
            {
                this.os = os;
            }
            else
            {
                throw new Exception("OS non valide");
            }
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
