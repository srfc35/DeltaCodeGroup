using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryDelta.Entities
{
    public class Computer:Product
    {
        #region Attribut
        [Required]
        private int ramMemory;
        #endregion

        #region Properties
        public int RamMemory
        {
            get { return ramMemory; }
            set { ramMemory = value; }
        }
        #endregion

        #region Constructor
        public Computer(int ramMemory, int productID, string nameProduct, string brand, int size,
           float unitPriceHT, float vatRate, float discount, float weight, string color) : base(productID, nameProduct, brand, size,
                        unitPriceHT, vatRate, discount, weight, color)
        {
            this.ramMemory = ramMemory;
        }

        public Computer()
        {
        }

        #endregion

        #region Method
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public void UpdateRamMemory(int ram)
        {
            if (ram>0)
            {
                RamMemory = ram;
            }
        }
        #endregion
    }
}
