using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    class ItemsOfVATsEditorViewModel : EditorViewModel<ItemOfVAT>
    {
        public ItemsOfVATsEditorViewModel(Type editorWindowType, VATItemsViewModel vatItemsViewModel)
            : base(editorWindowType)
        {
            ItemSelectControlViewModel = new ItemSelectControlViewModel(vatItemsViewModel, UpdateItem);
        }

        public ItemSelectControlViewModel ItemSelectControlViewModel { get; private set; }

        public double Amount
        {
            get
            {
                return Item.Amount;
            }

            set
            {
                Item.Amount = value;
                ActionCommand.RaiseCanExecuteChanged();
            }
        }

        private void UpdateItem(BasicEntity entity)
        {
            var vatitem = entity as VATItem;

            Item.VATItemId = vatitem.Id;
            Item.VATItem = vatitem;
            ActionCommand.RaiseCanExecuteChanged();
        }

        public override void Show(Action<object> saveAction, ItemOfVAT item)
        {
            Item = item;
            action = saveAction;
            ItemSelectControlViewModel.Entity = Item.VATItem;
            ShowDialogOfType(windowType, out window, this);
        }
    }
}
