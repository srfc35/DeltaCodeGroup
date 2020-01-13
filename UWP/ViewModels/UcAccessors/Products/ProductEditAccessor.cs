using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;

namespace UWP.ViewModels.UcAccessors.Products
{
    public class ProductEditAccessor
    {
        public Product Product { get; set; }
        public ButtonAccessor Button { get; set; }

        public ProductEditAccessor()
        {
            this.Product = new Product();
            this.Button = new ButtonAccessor();
        }
    }
}
