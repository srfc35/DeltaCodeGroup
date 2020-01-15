using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWP.Entities;
using UWP.Services;

namespace UWP.ViewModels
{
    public class PhonePageViewModel
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public float Amount { get; set; }

        public ObservableCollection<Phone> Phones { get; set; }

        public PhonePageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupPhoneList();
        }

        private void SetupPhoneList()
        {
            this.Phones = new ObservableCollection<Phone>();
            foreach (var item in databaseService.Phones)
            {
                Phones.Add(item);
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
    }
}
