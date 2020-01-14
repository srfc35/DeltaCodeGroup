using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWP.Services;

namespace UWP.ViewModels
{
    public class ViewModelLocator
    {
        public enum Pages
        {
            ProductPage
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                navigationService.Configure(Pages.ProductPage.ToString(), typeof(ProductPage));
                return navigationService;
            });

            SimpleIoc.Default.Register<ProductPageViewModel>();

            SimpleIoc.Default.Register<DatabaseService>(() =>
            {
                return new DatabaseService();
            }, true);
        }

        public ProductPageViewModel ProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ProductPageViewModel>(); }
        }
    }
}
