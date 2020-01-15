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
    public class ComputerPageViewModel
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public ObservableCollection<Computer> Computers { get; set; }

        public ComputerPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupComputerList();
        }

        private void SetupComputerList()
        {
            this.Computers = new ObservableCollection<Computer>();
            Debug.WriteLine("Computers");
            foreach (var item in databaseService.Computers)
            {
                Computers.Add(item);
                Debug.WriteLine(item);
            }

            /*
            Datas.RoleList.ListView.SelectedItem = new Role();
            Datas.RoleList.ListView.SelectionChanged = new RelayCommand(RoleListSelectionChanged);
            */
        }
    }
}
