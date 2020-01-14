using System.Collections.ObjectModel;
using UWP.Entities;

namespace UWP.ViewModels.UcAccessors.Products
{
    public class ListComputers
    {
        public ObservableCollection<Computer> Computers { get; set; }
        public ListViewAccessor<Computer> ComputerListView { get; set; }
    }
}