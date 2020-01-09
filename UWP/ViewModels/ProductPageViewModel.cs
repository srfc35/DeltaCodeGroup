using ClassLibraryDelta.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public Product Product { get; set; }
        public string ButtonContent { get; set; }
        public ICommand ProductButtonClick => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ProductListPage");
            MessengerInstance.Send<NotificationMessage<Product>>(
                new NotificationMessage<Product>(this.Product, "User from ProductPage"), "ProductPageProductSender");
        });

        public ProductPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        //    this.Product = new Product() { NameProduct = "Samsung Galaxy 7" };
            this.ButtonContent = "Valider";
        }
    }
}
