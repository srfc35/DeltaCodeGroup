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
            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                // Ajouter nos pages comme dans les exemples ci-dessous:
                //navigationService.Configure("BlankPage", typeof(BlankPage));
                //navigationService.Configure("OtherPage", typeof(OtherPage));
                return navigationService;
            });
            // Enregistrer les ViewModels ici, comme dans les exemples ci-dessous:
            //SimpleIoc.Default.Register<BlankPageViewModel>();
            //SimpleIoc.Default.Register<OtherPageViewModel>();
        }

        // Mettre nos ViewModel ici, comme dans les exemples ci-dessous:
       /* public BlankPageViewModel BlankPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<BlankPageViewModel>(); }
        }
        public OtherPageViewModel MyProperty
        {
            get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        }*/
    }
}
