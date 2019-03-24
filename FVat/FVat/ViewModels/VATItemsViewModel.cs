using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    sealed class VATItemsViewModel : ListViewModel<VATItem>
    {
        public VATItemsViewModel()
            : base()
        {
        }

        protected override async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (SelectedItem == null)
                    throw new Exception("Selected item is null");

                await DAL.VATItemsManager.RemoveItemAsync(SelectedItem);
                UpdateList();
            }
            catch { throw; }
        }

        protected override void UpdateList()
        {
            ItemsList = new ObservableCollection<VATItem>(DAL.VATItemsManager.GetItems());
        }
    }
}
