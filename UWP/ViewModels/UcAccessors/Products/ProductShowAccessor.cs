using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;

namespace UWP.ViewModels.UcAccessors.Products
{
    public class ProductShowAccessor
    {
        public Product Product { get; set; }

        public ProductShowAccessor()
        {
            this.Product = new Product();
        }
    }
}
