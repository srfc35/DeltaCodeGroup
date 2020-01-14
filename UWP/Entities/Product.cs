using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;

namespace UWP.Entities
{
    public class Product : EntityBase
    {
        #region Attributes
        private int productID;
        private string nameProduct;
        private string brand;
        private int size;
        private float unitPriceHT;
        internal static float vatRate = 0.20f;
        private float discount;
        private float weight;
        private string color;
        private int status; // 0: en stock, 1: demande d'achat, 2: demande d'achat rejetee, 3: vendu ...
        private Command order;
        #endregion

        #region Properties

        [PrimaryKey, AutoIncrement]
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string NameProduct
        {
            get { return nameProduct; }
            set { nameProduct = value;
                OnPropertyChanged("NameProduct");
            }
        }

        [NotNull]
        public string Brand
        {
            get { return brand; }
            set { brand = value;
                OnPropertyChanged("Brand");
            }
        }

        [NotNull]
        public int Size
        {
            get { return size; }
            set { size = value;
                OnPropertyChanged("Size");
            }
        }

        [NotNull]
        public float UnitPriceHT
        {
            get { return unitPriceHT; }
            set { unitPriceHT = value;
                OnPropertyChanged("UnitPriceHT");
            }
        }

        [NotNull]
        public static float VatRate
        {
            get { return vatRate; }
            set { vatRate = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value;
                OnPropertyChanged("Weight");
            }
        }

        [NotNull]
        public float Discount
        {
            get { return discount; }
            set { discount = value;
                OnPropertyChanged("Discount");
            }
        }

        public string Color
        {
            get { return color; }
            set { color = value;
                OnPropertyChanged("Color");
            }
        }

        [NotNull]
        public int Status
        {
            get { return status; }
            set { status = value;
                OnPropertyChanged("Status");
            }
        }

        [ManyToOne]
        public Command Order
        {
            get { return order; }
            set { order = value;
                OnPropertyChanged("Order");
            }
        }

        private int commandId;

        [ForeignKey(typeof(Command))]
        public int CommandId
        {
            get { return commandId; }
            set { commandId = value; }
        }


        #endregion

        #region Constructors

        public Product()
        {

        }

        public Product(int productID, string nameProduct, string brand, int size,
            float unitPriceHT, float discount, float weight, string color)
        {
            if (brand.Equals("") || size <= 0 || unitPriceHT < 0 || discount < 0 || weight < 0)
            {
                throw new Exception("Données incorrectes");
            }
            else
            {
                this.nameProduct = nameProduct;
                this.brand = brand;
                this.size = size;
                this.unitPriceHT = unitPriceHT;
                this.discount = discount;
                this.weight = weight;
                this.color = color;
                this.status = 0; //0 : "en stock"
            }

        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public void UpdateBrand(string brand)
        {
            if (!brand.Equals(""))
            {
                Brand = brand;
            }
            else
            {
                throw new Exception("Marque invalide");
            }
        }

        public void UpdateSize(int size)
        {
            if (size > 0)
            {
                Size = size;
            }
            else
            {
                throw new Exception("Taille invalide");
            }
        }

        public void UpdatePrice(float price)
        {
            if (price > 0)
            {
                UnitPriceHT = price;
            }
            else
            {
                throw new Exception("Prix invalide");
            }
        }

        public void UpdateDiscount(float discount)
        {
            if (discount > 0)
            {
                Discount = discount;
            }
            else
            {
                throw new Exception("Remise invalide");
            }
        }

        public void UpdateWeight(float weight)
        {
            if (weight > 0)
            {
                Weight = weight;
            }
            else
            {
                throw new Exception("Poids invalide");
            }
        }

        public void UpdateColor(string color)
        {
            if (!color.Equals(""))
            {
                Color = color;
            }
            else
            {
                throw new Exception("Couleur invalide");
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

        public override object Copy()
        {
            Product product = new Product();
            product.ProductID = this.ProductID;
            product.NameProduct = this.NameProduct;
            product.Brand = this.Brand;
            product.Size = this.Size;
            product.UnitPriceHT = this.UnitPriceHT;
            product.Discount = this.Discount;
            product.Weight = this.Weight;
            product.Color = this.Color;
            product.Order = this.Order;

            return product;
        }

        public override void CopyFrom(object obj)
        {
            Product product = obj as Product;
            this.ProductID = product.ProductID;
            this.NameProduct = product.NameProduct;
            this.Brand = product.Brand;
            this.Size = product.Size;
            this.UnitPriceHT = product.UnitPriceHT;
            this.Discount = product.Discount;
            this.Weight = product.Weight;
            this.Color = product.Color;
            this.Order = product.Order;
        }

        #endregion


    }
}
