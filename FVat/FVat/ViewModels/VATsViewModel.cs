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
        public VATsViewModel(Type dialogWindowType)
            : base(dialogWindowType)
        {
            ShowVATItemsWindow = new Commands.Command(OnShowVATItemsWindow);
            ShowVATEntitiesWindow = new Commands.Command(OnShowVATEntitiesWindow);
        }

        public Action ViewDocument { get; set; }

        public VATEntitiesViewModel VATEntitiesViewModel { get; set; }
        public VATItemsViewModel VATItemsViewModel { get; set; }

        public Commands.Command ShowVATItemsWindow { get; private set; }
        public Commands.Command ShowVATEntitiesWindow { get; private set; }

        public override VAT SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                DeleteCommand.RaiseCanExecuteChanged();
                ModifyCommand.RaiseCanExecuteChanged();
                ActionCommand.RaiseCanExecuteChanged();
                OnNotifyPropertyChanged();

                ViewDocument?.Invoke();
            }
        }

        protected override async void OnAddAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATsManager.AddNewVATAsync(parameter as VAT);
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

                await DAL.VATsManager.ModifyVATAsync(parameter as VAT);
                UpdateList();
            }
            catch { throw; }
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

        private void OnShowVATItemsWindow(object parameter)
        {
            VATItemsViewModel.ShowDialog(null, null);
        }

        private void OnShowVATEntitiesWindow(object parameter)
        {
            VATEntitiesViewModel.ShowDialog(null, null);
        }

        protected override bool CanExecuteAction()
        {
            return SelectedItem != null;
        }
    }
}
