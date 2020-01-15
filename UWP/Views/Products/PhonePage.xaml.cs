using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Views.Products
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PhonePage : Page, INavigationEvent
    {
        public PhonePageViewModel ViewModel { get; set; }

        public PhonePage()
        {
            this.InitializeComponent();
        }

        void INavigationEvent.OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            (this.DataContext as INavigationEvent).OnNavigatedTo(e);
            if (ViewModel.Amount.Equals(null))
            {
                ViewModel.Amount = 0;
            }
            else
            {
                ViewModel.Amount = (float)e.Parameter;
            }
        }

        void INavigationEvent.OnNavigatedFrom(NavigationEventArgs e)
        {

        }
    }
}
