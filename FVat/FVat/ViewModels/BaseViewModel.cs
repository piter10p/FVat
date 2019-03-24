using FVat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FVat.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public Commands.Command ShowWindowCommand { get; private set; }
        public Commands.Command CloseWindowCommand { get; private set; }

        public BaseViewModel()
        {
            ShowWindowCommand = new Commands.Command(OnShowWindow);
            CloseWindowCommand = new Commands.Command(OnCloseWindow);
        }

        private void OnShowWindow(object parameter)
        {
            try
            {
                var showable = parameter as IShowable;
                showable.Show();
            }
            catch { throw; }
        }

        private void OnCloseWindow(object parameter)
        {
            try
            {
                var closable = parameter as IClosable;
                closable.Close();
            }
            catch { throw; }
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(memberName));
            }
        }
    }
}
