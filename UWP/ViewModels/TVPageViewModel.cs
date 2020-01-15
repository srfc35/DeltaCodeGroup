using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWP.Entities;
using UWP.Services;
using Windows.UI.Xaml.Navigation;

namespace UWP.ViewModels
{
    public class TVPageViewModel : INavigationEvent, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private INavigationService navigationService;
        private DatabaseService databaseService;

        private float amount;

        public float Amount
        {
            get { return amount; }
            set 
            { 
                amount = value;
                OnPropertyChanged("Amount");
            }
        }


        public ObservableCollection<TV> TVs { get; set; }

        public TVPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupTVList();
            this.Amount = 0;
        }

        private void SetupTVList()
        {
            this.TVs = new ObservableCollection<TV>();
            foreach (var item in databaseService.TVs)
            {
                TVs.Add(item);
            }

            /*
            Datas.RoleList.ListView.SelectedItem = new Role();
            Datas.RoleList.ListView.SelectionChanged = new RelayCommand(RoleListSelectionChanged);
            */
        }

        public ICommand Go_Back_Click => new RelayCommand(() =>
        {
            this.navigationService.GoBack();
        });

        public ICommand Add_To_Cart_Click => new RelayCommand<float>((float UnitPriceHT) =>
        {
            this.UpdateAmount(UnitPriceHT);
        });
        
        public void UpdateAmount(float productPrice)
        {
            this.Amount += productPrice;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {

            if (this.Amount.Equals(null))
            {
                this.Amount = 0;
            }
            else
            {
                this.Amount = (float)e.Parameter;
            }
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }
    }
}
