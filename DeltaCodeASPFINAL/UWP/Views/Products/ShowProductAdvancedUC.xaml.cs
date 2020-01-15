using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP.Entities;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP.Views.Products
{
    public sealed partial class ShowProductAdvancedUC : UserControl
    {
        public Product Product { get; set; }
        public ShowProductAdvancedUC()
        {
            this.InitializeComponent();
            this.Product = new Product();
            this.DataContext = this.Product;
            if (this.Product.Order != null)
            {
                //this.orderUc.Role.CopyFrom(this.Product.Order);
            }
        }
    }
}
