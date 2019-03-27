using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    class ItemSelectControlViewModel: BaseViewModel
    {
        private BasicEntity _entity;
        private DialogViewModel dialogViewModel;

        private Action<BasicEntity> callback;

        public Commands.Command SelectionCommand { get; private set; }
        public BasicEntity Entity
        {
            get
            {
                return _entity;
            }

            set
            {
                _entity = value;
                OnNotifyPropertyChanged("EntityName");
            }
        }

        public string EntityName
        {
            get
            {
                if (Entity == null)
                    return "";

                return Entity.Name;
            }
        }

        public ItemSelectControlViewModel(DialogViewModel dialogViewModel, Action<BasicEntity> callback)
        {
            SelectionCommand = new Commands.Command(CallSelectionCommand);
            this.dialogViewModel = dialogViewModel;
            this.callback = callback;
        }

        private void CallSelectionCommand(object parameter)
        {
            dialogViewModel.ShowDialog(SelectionDialogCallback, Entity);
        }

        private void SelectionDialogCallback(object entity)
        {
            Entity = entity as BasicEntity;
            callback(Entity);
        }
    }
}
