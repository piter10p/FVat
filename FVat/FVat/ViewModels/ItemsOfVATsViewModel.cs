using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    class ItemsOfVATsViewModel : ListViewModel<ItemOfVAT>
    {
        public VAT VAT { get; private set; }

        public ItemsOfVATsViewModel(Type windowType, VAT vat)
            :base(windowType)
        {
            VAT = vat;
            UpdateList();
        }

        protected override async void OnAddAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                var item = parameter as ItemOfVAT;
                item.VAT = VAT;

                await DAL.ItemsOfVATsManager.AddItemOfVAT(item);
                UpdateList();
            }
            catch { throw; }
        }

        protected override async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.ItemsOfVATsManager.RemoveItemOfVATAsync(parameter as ItemOfVAT);
                UpdateList();
            }
            catch { throw; }
        }

        protected override async void OnModifyAsync(object parameter)
        {
            try
            {
                if (SelectedItem == null)
                    throw new Exception("Selected itemOfVat is null");

                await DAL.ItemsOfVATsManager.ModifyItemAsync(SelectedItem);
                UpdateList();
            }
            catch { throw; }
        }

        protected override void UpdateList()
        {
            if(VAT != null)
                ItemsList = new ObservableCollection<ItemOfVAT>(DAL.ItemsOfVATsManager.GetItemsofVAT(VAT));
        }
    }
}
