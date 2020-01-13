using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;

namespace UWP.ViewModels.UcAccessors.Products
{
    public class ProductListAccessor
    {
        //public ListComputers ListComputers { get; set; }
        public ObservableCollection<Computer> Computers { get; set; }
        public ObservableCollection<Phone> Phones { get; set; }
        public ObservableCollection<Tablet> Tablets { get; set; }
        public ObservableCollection<TV> TVs { get; set; }
        public ListViewAccessor<Computer> ComputerListView { get; set; }
        public ListViewAccessor<Phone> PhoneListView { get; set; }
        public ListViewAccessor<Tablet> TabletListView { get; set; }
        public ListViewAccessor<TV> TVListView { get; set; }

        public ProductListAccessor()
        {
            this.Computers = new ObservableCollection<Computer>();
            this.Phones = new ObservableCollection<Phone>();
            this.Tablets = new ObservableCollection<Tablet>();
            this.TVs = new ObservableCollection<TV>();
            this.ComputerListView = new ListViewAccessor<Computer>();
            this.PhoneListView = new ListViewAccessor<Phone>();
            this.TabletListView = new ListViewAccessor<Tablet>();
            this.TVListView = new ListViewAccessor<TV>();
        }
    }
}
