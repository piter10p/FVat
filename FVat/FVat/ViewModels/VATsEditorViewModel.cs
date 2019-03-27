using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    sealed class VATsEditorViewModel: EditorViewModel<VAT>
    {
        public VATsEditorViewModel(Type editorWindowType, VATEntitiesViewModel vatEntitiesViewModel)
            : base(editorWindowType)
        {
            CreateControlViewsModels(vatEntitiesViewModel);
        }

        public ItemSelectControlViewModel IssuerControlViewModel { get; private set; }
        public ItemSelectControlViewModel ReceiverControlViewModel { get; private set; }

        public override void Show(Action<object> saveAction, VAT item)
        {
            Item = item;
            action = saveAction;
            IssuerControlViewModel.Entity = Item.Issuer;
            ReceiverControlViewModel.Entity = Item.Receiver;
            ShowDialogOfType(windowType, out window, this);
        }

        public string Number
        {
            get
            {
                return Item.Name;
            }

            set
            {
                Item.Name = value;
                ActionCommand.RaiseCanExecuteChanged();
            }
        }

        private void CreateControlViewsModels(VATEntitiesViewModel vatEntitiesViewModel)
        {
            IssuerControlViewModel = new ItemSelectControlViewModel(vatEntitiesViewModel, UpdateIssuer);
            ReceiverControlViewModel = new ItemSelectControlViewModel(vatEntitiesViewModel, UpdateReceiver);
        }

        private void UpdateIssuer(BasicEntity entity)
        {
            Item.Issuer = entity as VATEntity;
        }

        private void UpdateReceiver(BasicEntity entity)
        {
            Item.Receiver = entity as VATEntity;
        }
    }
}
