﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Entities
{
    public class TV : Product
    {
        #region Attributes
        private float resolution;
        #endregion

        #region Properties

        [NotNull]
        public float Resolution
        {
            get { return resolution; }
            set { resolution = value;
                OnPropertyChanged("Resolution");
            }
        }
        #endregion

        #region Constructor

        public TV(int productID, string nameProduct, string brand, int size,
            float unitPriceHT, float discount, float weight, string color, float resolution) : base(productID, nameProduct, brand, size,
                          unitPriceHT, discount, weight, color)
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
