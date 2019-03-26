using FVat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    class VATsViewModel : ListViewModel<VAT>
    {
        public VATsViewModel()
            : base()
        {
        }

        protected override async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (SelectedItem == null)
                    throw new Exception("Selected vat is null");

                await DAL.VATsManager.RemoveVATAsync(SelectedItem);
                UpdateList();
            }
            catch { throw; }
        }

        protected override void UpdateList()
        {
            ItemsList = new ObservableCollection<VAT>(DAL.VATsManager.GetEntities());
        }
    }
}
