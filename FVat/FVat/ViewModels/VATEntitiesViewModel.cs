using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Commands;
using FVat.Models;

namespace FVat.ViewModels
{
    sealed class VATEntitiesViewModel: ListViewModel<VATEntity>
    {
        public VATEntitiesViewModel()
            :base()
        {
        }

        protected override async void OnAddAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATEntitiesManager.AddNewEntityAsync(parameter as VATEntity);
                UpdateList();
            }
            catch { throw; }
        }

        protected override async void OnModifyAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATEntitiesManager.ModifyEntityAsync(parameter as VATEntity);
                UpdateList();
            }
            catch { throw; }
        }

        protected override async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (SelectedItem == null)
                    throw new Exception("Selected entity is null");

                await DAL.VATEntitiesManager.RemoveEntityAsync(SelectedItem);
                UpdateList();
            }
            catch { throw; }
        }

        protected override void UpdateList()
        {
            ItemsList = new ObservableCollection<VATEntity>(DAL.VATEntitiesManager.GetEntities());
        }
    }
}
