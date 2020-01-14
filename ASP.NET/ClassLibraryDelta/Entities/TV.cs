using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    [Table("TV")]
    public class TV : Product
    {
        #region Attribut
        private float resolution;

       

        public  float Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        #endregion
        #region Constructor


        public TV(int productID, string nameProduct, string brand, int size,
            float unitPriceHT, float vatRate, float discount, float weight, string color, float resolution) : base(productID, nameProduct, brand, size,
                          unitPriceHT, vatRate, discount, weight, color)
        {
            this.resolution = resolution;
        }

        public TV()
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
