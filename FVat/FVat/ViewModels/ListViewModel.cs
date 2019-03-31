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
        protected T _selectedItem;
        private ObservableCollection<T> _list;

        public Command DeleteCommand { get; private set; }
        public Command AddCommand { get; private set; }
        public Command ModifyCommand { get; private set; }

        public EditorViewModel<T> EditorViewModel { get; set; }

        public ListViewModel(Type dialogWindowType)
            :base(dialogWindowType)
        {
            DeleteCommand = new Command(OnDeleteAsync, CanExecuteAction);
            AddCommand = new Command(OnAddCommand);
            ModifyCommand = new Command(OnModifyCommand, CanExecuteAction);
            UpdateList();
        }

        public virtual T SelectedItem
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

        public override void Show(Action<object> action, object parameter)
        {
            this.action = action;
            this.SelectedItem = (T)parameter;
            ActionCommand.RaiseCanExecuteChanged();
            OnNotifyPropertyChanged("SelectedItem");
            ShowOfType(windowType, out window, this);
        }

        public override void ShowDialog(Action<object> action, object parameter)
        {
            this.action = action;
            this.SelectedItem = (T)parameter;
            ActionCommand.RaiseCanExecuteChanged();
            OnNotifyPropertyChanged("SelectedItem");
            ShowDialogOfType(windowType, out window, this);
        }

        protected abstract void OnDeleteAsync(object parameter);
        protected abstract void OnAddAsync(object parameter);
        protected abstract void OnModifyAsync(object parameter);
        protected abstract void UpdateList();

        private void OnAddCommand(object parameter)
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            EditorViewModel.Show(OnAddAsync, instance);
        }

        private void OnModifyCommand(object parameter)
        {
            EditorViewModel.Show(OnModifyAsync, SelectedItem);
        }

        protected override bool CanExecuteAction()
        {
            if (SelectedItem == null)
                return false;
            return true;
        }
    }
}
