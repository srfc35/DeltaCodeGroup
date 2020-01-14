using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.ViewModels.UcAccessors.Products;

namespace UWP.ViewModels.UcAccessors
{
    public class ProductPageAccessor
    {
        public ProductEditAccessor ProductEdit { get; set; }
        public ProductListAccessor ProductList { get; set; }
        public ProductShowAccessor ProductShow { get; set; }

        public ProductPageAccessor()
        {
            this.ProductEdit = new ProductEditAccessor();
            this.ProductList = new ProductListAccessor();
            this.ProductShow = new ProductShowAccessor();
        }
    }
}