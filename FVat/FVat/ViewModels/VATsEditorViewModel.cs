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
        private Type itemsOfVATsWindowType;
        private Type itemsOfVATsEditorWindowType;
        private VATItemsViewModel vatItemsViewModel;

        public VATsEditorViewModel(Type editorWindowType, VATEntitiesViewModel vatEntitiesViewModel, VATItemsViewModel vatItemsViewModel, Type itemsOfVATsWindowType, Type itemsOfVATsEditorWindowType)
            : base(editorWindowType)
        {
            this.itemsOfVATsWindowType = itemsOfVATsWindowType;
            this.itemsOfVATsEditorWindowType = itemsOfVATsEditorWindowType;
            this.vatItemsViewModel = vatItemsViewModel;
            OpenItemsOfVATsEditor = new Commands.Command(OnOpenItemsOfVATsEditor, CanOpenItemsOfVATsEditor);
            CreateViewModels(vatEntitiesViewModel);
        }

        public ItemSelectControlViewModel IssuerControlViewModel { get; private set; }
        public ItemSelectControlViewModel ReceiverControlViewModel { get; private set; }
        public ItemsOfVATsViewModel ItemsOfVATsViewModel { get; private set; }

        public Commands.Command OpenItemsOfVATsEditor { get; private set; }

        public override void Show(Action<object> saveAction, VAT item)
        {
            Item = item;
            action = saveAction;
            IssuerControlViewModel.Entity = Item.Issuer;
            ReceiverControlViewModel.Entity = Item.Receiver;
            ItemsOfVATsViewModel = new ItemsOfVATsViewModel(itemsOfVATsWindowType, item);
            ItemsOfVATsViewModel.EditorViewModel = new ItemsOfVATsEditorViewModel(itemsOfVATsEditorWindowType, vatItemsViewModel);
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

        public object AsyncHelpers { get; private set; }

        private void CreateViewModels(VATEntitiesViewModel vatEntitiesViewModel)
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

        private void OnOpenItemsOfVATsEditor(object parameter)
        {
            ItemsOfVATsViewModel.ShowDialog(null, null);
        }

        private bool CanOpenItemsOfVATsEditor()
        {
            return DAL.VATsManager.VATExists(Item);
        }
    }
}
