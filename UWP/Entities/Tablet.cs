using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Entities
{
    public class Tablet : Product
    {
        #region Attributes
        private float screenSize;
        #endregion

        #region Properties

        [NotNull]
        public float ScreenSize
        {
            get { return screenSize; }
            set {
                screenSize = value;
                OnPropertyChanged("ScreenSize");
            }
        }
        #endregion

        #region Constructor
        public Tablet(float screenSize, int productID, string nameProduct, string brand, int size,
           float unitPriceHT, float vatRate, float discount, float weight,
           string color) : base(productID, nameProduct, brand, size,
                         unitPriceHT, vatRate, discount, weight, color)
        {
            if (screenSize > 0)
            {
                this.screenSize = screenSize;
            }
            else
            {
                throw new Exception("Taille non valide");
            }
        }

        public Tablet()
        {
        }

        #endregion

        #region Methods
        public void UpdateScreenSize(float screenSize)
        {
            if (screenSize > 0)
            {
                ScreenSize = screenSize;
            }
            else
            {
                throw new Exception("Taille non valide");
            }
        }
        #endregion

    }
}
