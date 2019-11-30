using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryDelta.Entities
{
    public class TV : Product
    {
        #region Attribut
        [Required]
        private float resolution;
        #endregion

        #region Properties
        public float Resolution
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
            if (resolution > 0)
            {
                this.resolution = resolution;
            }
            else
            {
                throw new Exception("Résolution non valide");
            }
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

        public void UpdateResolution(float resolution)
        {
            if (resolution > 0)
            {
                Resolution = resolution;
            }
            else
            {
                throw new Exception("Résolution non valide");
            }
        }
        #endregion
    }

}
