using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    abstract class EditorViewModel<T>: DialogViewModel
    {
        private T _item;

        public void Show(Action<object> saveAction, T item)
        {
            Item = item;
            action = saveAction;
            ShowDialogOfType(windowType, out window, this);
        }

        public T Item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
            }
        }

        public EditorViewModel(Type editorWindowType)
            :base(editorWindowType)
        {
        }

        protected override bool CanExecuteAction()
        {
            var context = new ValidationContext(Item, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(Item, context, results))
                return true;
            return false;
        }
    }
}
