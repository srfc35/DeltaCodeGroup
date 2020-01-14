using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;

namespace UWP.ViewModels.UcAccessors.Products
{
    public class ListComputers
    {
       
        public ObservableCollection<Computer> Computers { get; set; }
        public ListViewAccessor<Computer> ComputerListView { get; set; }
    }
}
  
