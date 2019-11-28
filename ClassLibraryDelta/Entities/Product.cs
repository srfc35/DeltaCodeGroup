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
        private float unitPriceHT;
        private static float vatRate = 0.20;
        private  float discount;
        private float weight;
        private string color;
        private Command order;
        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        [Required]
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        [Required]
        public float UnitPriceHT
        {
            get { return unitPriceHT; }
            set { unitPriceHT = value; }
        }

        [Required]
        public float VatRate
        {
            get { return vatRate; }
            set { vatRate = value; }
        }

        [Required]
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        [Required]
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        [Required]
        public string  Color
        {
            get { return color; }
            set { color = value; }
        }

        public Command Order
        {
            get { return order; }
            set { order = value; }
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

        public void UpdateBrand(string brand)
        {
            if (!color.Equals(""))
            {
                Brand = color;
            }
        }

        public void UpdateSize(int size)
        {
            if (size>0)
            {
                Size = size;
            }
        }

        public void UpdatePrice(float price)
        {
            if (price > 0)
            {
                Price = price;
            }
        }

        public void UpdateDiscount(float discount)
        {
            if (discount > 0)
            {
                Discount = discount;
            }
        }

        public void UpdateWeight(float weight)
        {
            if (weight > 0)
            {
                Weight = weight;
            }
        }

        public void UpdateBrand(string color)
        {
            if (!color.Equals(""))
            {
                Color = color;
            }
        }

        public void AddToOrder(Command command)
        {
            Order = command;
        }

        public void RemoveFromOrder()
        {
            Order = null;
        }

        #endregion


    }
}
