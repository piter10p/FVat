using FVat.Commands;
using FVat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    abstract class ListViewModel<T>: DialogViewModel
    {
        private T _selectedItem;
        private ObservableCollection<T> _list;

        public Command DeleteCommand { get; private set; }
        public Command AddCommand { get; private set; }
        public Command ModifyCommand { get; private set; }

        public EditorViewModel<T> EditorViewModel { get; set; }

        public ListViewModel(Type dialogWindowType)
            :base(dialogWindowType)
        {
            DeleteCommand = new Command(OnDeleteAsync, CanDeleteOrModify);
            AddCommand = new Command(OnAddCommand);
            ModifyCommand = new Command(OnModifyCommand, CanDeleteOrModify);
            UpdateList();
        }

        public T SelectedItem
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
                OnNotifyPropertyChanged("IsItemSelected");
            }
        }

        public ObservableCollection<T> ItemsList
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
                OnNotifyPropertyChanged();
            }
        }

        public bool IsItemSelected
        {
            get
            {
                return SelectedItem != null;
            }
        }

        protected abstract void OnDeleteAsync(object parameter);
        protected abstract void OnAddAsync(object parameter);
        protected abstract void OnModifyAsync(object parameter);
        protected abstract void UpdateList();

        private bool CanDeleteOrModify()
        {
            return IsItemSelected;
        }

        private void OnAddCommand(object parameter)
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            EditorViewModel.Show(OnAddAsync, instance);
        }

        private void OnModifyCommand(object parameter)
        {
            EditorViewModel.Show(OnModifyAsync, SelectedItem);
        }
    }
}
