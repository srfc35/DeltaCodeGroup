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
using ClassLibraryDelta.Entities;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP
{
    public sealed partial class ShowProductAdvanced : UserControl
    {
        public Product Product;
        public ShowProductAdvanced()
        {
            this.InitializeComponent();
            this.Product = new Product(10, "Ordi dernier cri", "Dell", 16, 800, 0.2f, 0, 2.5f, "Black");
            Client c = new Client();
            c.LastName = "UnClient";
            Seller s = new Seller();
            s.LastName = "UnVendeur";
            Command o = new Command(c, s);
            o.DateCommand = DateTime.Today.Date;
            o.CommandID = 10;
            this.Product.Order = o;
            this.DataContext = this;
        }
    }
}
