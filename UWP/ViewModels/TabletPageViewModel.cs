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
    public class TabletPageViewModel
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public float Amount { get; set; }

        public ObservableCollection<Tablet> Tablets { get; set; }

        public TabletPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupTabletList();
        }

        private void SetupTabletList()
        {
            this.Tablets = new ObservableCollection<Tablet>();
            foreach (var item in databaseService.Tablets)
            {
                Tablets.Add(item);
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
