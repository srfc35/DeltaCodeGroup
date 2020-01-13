using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    [Table("Tablet")]
    public class Tablet:Product
    {
        #region Attribut
        private float screenSize;

      

        public float ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }



        #endregion
        #region Constructor
        public Tablet(float screenSize, int productID, string nameProduct, string brand, int size,
           float unitPriceHT, float vatRate, float discount, float weight,
           string color) : base(productID, nameProduct, brand, size,
                         unitPriceHT, vatRate, discount, weight, color)
        {
            this.screenSize = screenSize;
        }

        public Tablet()
        {
        }

        #endregion


    }
}
