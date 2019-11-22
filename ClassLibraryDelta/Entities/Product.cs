using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDelta.Entities
{
    public class Product


    {
        #region Attribut
        private int productID;
        private string nameProduct;
        private string brand;
        private int size;
        private  float unitPriceHT;
        private float vatRate;
        private  float discount;
        private float weight;
        private  string color;
        



       

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string NameProduct
        {
            get { return nameProduct; }
            set { nameProduct = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

       

        public float UnitPriceHT
        {
            get { return unitPriceHT; }
            set { unitPriceHT = value; }
        }
        public float VatRate
        {
            get { return vatRate; }
            set { vatRate = value; }
        }
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        

        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public string  Color
        {
            get { return color; }
            set { color = value; }
        }
      

        



        #endregion

        #region Constructors

        public Product()
        {


        }

        public Product(int productID, string nameProduct, string brand, int size,
            float unitPriceHT, float vatRate, float discount, float weight, string color)
        {
            this.productID = productID;
            this.nameProduct = nameProduct;
            this.brand = brand;
            this.size = size;
            this.unitPriceHT = unitPriceHT;
            this.vatRate = vatRate;
            this.discount = discount;
            this.weight = weight;
            this.color = color;
           
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
