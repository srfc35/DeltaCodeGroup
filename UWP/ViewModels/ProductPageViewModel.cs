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

namespace UWP.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public ProductPageAccessor Datas { get; set; }

        public ProductPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupDatas();
        }

        private void SetupDatas()
        {
            Datas = new ProductPageAccessor();
        //    SetupProductEdit();
            SetupProductList();
            //SetupProductShow();
        }

        private void SetupProductShow()
        {
            Datas.ProductShow.Product = new Product();
        }

        private void SetupProductList()
        {
            SetupComputerList();
            SetupPhoneList();
            SetupTabletList();
            SetupTVList();
        }

        private void SetupComputerList()
        {
            Datas.ProductList.Computers = new ObservableCollection<Computer>();
            foreach (var item in databaseService.Computers)
            {
                Datas.ProductList.Computers.Add(item);
            }
            Datas.ProductList.ComputerListView.SelectedItem = new Computer();
            Datas.ProductList.ComputerListView.SelectionChanged = new RelayCommand(ComputerListSelectionChanged);
        }

        private void SetupPhoneList()
        {
            Datas.ProductList.Phones = new ObservableCollection<Phone>();
            foreach (var item in databaseService.Phones)
            {
                Datas.ProductList.Phones.Add(item);
            }
            Datas.ProductList.PhoneListView.SelectedItem = new Phone();
            Datas.ProductList.PhoneListView.SelectionChanged = new RelayCommand(PhoneListSelectionChanged);
        }

        private void SetupTabletList()
        {
            Datas.ProductList.Tablets = new ObservableCollection<Tablet>();
            foreach (var item in databaseService.Tablets)
            {
                Datas.ProductList.Tablets.Add(item);
            }
            Datas.ProductList.TabletListView.SelectedItem = new Tablet();
            Datas.ProductList.TabletListView.SelectionChanged = new RelayCommand(TabletListSelectionChanged);
        }

        private void SetupTVList()
        {
            Datas.ProductList.TVs = new ObservableCollection<TV>();
            foreach (var item in databaseService.TVs)
            {
                Datas.ProductList.TVs.Add(item);
            }
            Datas.ProductList.TVListView.SelectedItem = new TV();
            Datas.ProductList.TVListView.SelectionChanged = new RelayCommand(TVListSelectionChanged);
        }

        private void ComputerListSelectionChanged()
        {
            Computer computer = Datas.ProductList.ComputerListView.SelectedItem;
            if (computer != null)
            {
                Datas.ProductShow.Product.CopyFrom(computer);
            }
        }

        private void PhoneListSelectionChanged()
        {
            Phone phone = Datas.ProductList.PhoneListView.SelectedItem;
            if (phone != null)
            {
                Datas.ProductShow.Product.CopyFrom(phone);
            }
        }

        private void TabletListSelectionChanged()
        {
            Tablet tablet = Datas.ProductList.TabletListView.SelectedItem;
            if (tablet != null)
            {
                Datas.ProductShow.Product.CopyFrom(tablet);
            }
        }

        private void TVListSelectionChanged()
        {
            TV tv = Datas.ProductList.TVListView.SelectedItem;
            if (tv != null)
            {
                Datas.ProductShow.Product.CopyFrom(tv);
            }
        }

        // A FAIRE POUR CHAQUE CLASSE
        /*
        private void SetupProductEdit()
        {
            Datas.ProductEdit.Button.Content = "Valider";
            Datas.ProductEdit.Button.Action = new RelayCommand(ProductEditCommand);
            Datas.ProductEdit.Product = new Product();
        }*/

        // A FAIRE POUR CHAQUE CLASSE

        /*
        private void ProductEditCommand()
        {
            Product product = new Product();
            product.CopyFrom(Datas.ProductEdit.Product);

            try
            {
                databaseService.SqliteConnection.Insert(product);
                Datas.ProductList.Products.Add(product);
            }
            catch (Exception e)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Error";
                contentDialog.Content = e.Message;
                contentDialog.IsSecondaryButtonEnabled = false;
                contentDialog.PrimaryButtonText = "ok";
                contentDialog.ShowAsync();
            }
        }*/
    }
}
