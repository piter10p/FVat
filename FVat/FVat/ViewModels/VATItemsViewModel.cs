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

        public async void AddNewItem(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATItemsManager.AddNewItemAsync(parameter as VATItem);
                UpdateList();
            }
            catch { throw; }
        }

        public async void ModifyItem(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATItemsManager.ModifyItemAsync(parameter as VATItem);
                UpdateList();
            }
            catch { throw; }
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
