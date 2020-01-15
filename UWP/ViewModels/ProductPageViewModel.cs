using UWP.Entities;
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
using UWP.Services;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;

namespace UWP.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;
        public float Amount { get; set; }

        public ProductPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;            
        }

        public ICommand Btn_Computer_Click => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ComputerPage");
        });

        public ICommand Btn_Phone_Click => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("PhonePage");
        });

        public ICommand Btn_Tablet_Click => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("TabletPage");
        });

        public ICommand Btn_TV_Click => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("TVPage");
        });
        
    }
}
