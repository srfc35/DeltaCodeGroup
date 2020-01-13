using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.ViewModels
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                // Ajouter nos pages ici
                navigationService.Configure("ProductPage", typeof(ProductPage));
                return navigationService;
            });
            // Enregistrer les ViewModels ici
            SimpleIoc.Default.Register<ProductPageViewModel>();
        }

        public ProductPageViewModel ProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ProductPageViewModel>(); }
        }
    }
}
