using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    abstract class DialogViewModel: BaseViewModel
    {
        protected Type windowType;
        protected Models.IClosable window;
        protected Action<object> action;

        public Commands.Command ActionCommand { get; private set; }

        public DialogViewModel(Type windowType)
        {
            this.windowType = windowType;
            ActionCommand = new Commands.Command(OnAction, CanExecute);
        }

        public virtual void Show(Action<object> action, object param)
        {
            this.action = action;
            ShowOfType(windowType, out window, this);
        }

        public virtual void ShowDialog(Action<object> action, object param)
        {
            this.action = action;
            ShowDialogOfType(windowType, out window, this);
        }

        protected abstract bool CanExecuteAction();

        private bool CanExecute()
        {
            if (action == null)
                return false;

            return CanExecuteAction();
        }

        private void OnAction(object parameter)
        {
            action(parameter);
            window.Close();
        }
    }
}
