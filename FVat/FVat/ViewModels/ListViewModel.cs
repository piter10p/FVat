using FVat.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    abstract class ListViewModel<T>: BaseViewModel
    {
        private T _selectedItem;
        private ObservableCollection<T> _list;

        public Command DeleteCommand { get; private set; }

        public ListViewModel()
        {
            DeleteCommand = new Command(OnDeleteAsync, CanDelete);
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
        protected abstract void UpdateList();

        private bool CanDelete()
        {
            return IsItemSelected;
        }
    }
}
