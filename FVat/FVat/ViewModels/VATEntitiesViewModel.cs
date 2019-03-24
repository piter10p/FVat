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
    class VATEntitiesViewModel: BaseViewModel
    {
        private VATEntity _selectedEntity;
        private ObservableCollection<VATEntity> _VATEntities;

        public Command DeleteCommand { get; private set; }

        public VATEntitiesViewModel()
        {
            DeleteCommand = new Command(OnDeleteAsync, CanDelete);
            UpdateEntities();
        }

        public VATEntity SelectedEntity
        {
            get
            {
                return _selectedEntity;
            }

            set
            {
                _selectedEntity = value;
                DeleteCommand.RaiseCanExecuteChanged();
                OnNotifyPropertyChanged("IsEntitySelected");
            }
        }

        public bool IsEntitySelected
        {
            get
            {
                return SelectedEntity != null;
            }
        }

        public ObservableCollection<VATEntity> VATEntities
        {
            get
            {
                return _VATEntities;
            }

            private set
            {
                _VATEntities = value;
                OnNotifyPropertyChanged();
            }
        }

        public async void AddNewEntity(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATEntitiesManager.AddNewEntityAsync(parameter as VATEntity);
                UpdateEntities();
            }
            catch { throw; }
        }

        public async void ModifyEntity(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATEntitiesManager.ModifyEntityAsync(parameter as VATEntity);
                UpdateEntities();
            }
            catch { throw; }
        }

        private async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (SelectedEntity == null)
                    throw new Exception("Selected entity is null");

                await DAL.VATEntitiesManager.RemoveEntityAsync(SelectedEntity);
                UpdateEntities();
            }
            catch { throw; }
        }

        private bool CanDelete()
        {
            return IsEntitySelected;
        }

        private void UpdateEntities()
        {
            VATEntities = new ObservableCollection<VATEntity>(DAL.VATEntitiesManager.GetEntities());
        }
    }
}
