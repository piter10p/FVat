using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    sealed class VATItemsEditorViewModel : EditorViewModel<VATItem>
    {
        public string Name
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

        public Unit Unit
        {
            get
            {
                return Item.Unit;
            }

            set
            {
                Item.Unit = value;
                ActionCommand.RaiseCanExecuteChanged();
            }
        }

        public VATRate VATRate
        {
            get
            {
                return Item.VATRate;
            }

            set
            {
                Item.VATRate = value;
                ActionCommand.RaiseCanExecuteChanged();
            }
        }

        public double UnitPrice
        {
            get
            {
                return Item.UnitPrice;
            }

            set
            {
                Item.UnitPrice = value;
                ActionCommand.RaiseCanExecuteChanged();
            }
        }

        public VATItemsEditorViewModel(Type editorWindowType)
            : base(editorWindowType)
        {
        }
    }
}
