using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    abstract class EditorViewModel<T>: BaseViewModel
    {
        private T _item;
        private Type editorWindowType;
        private Models.IClosable window;
        private Action<object> saveAction;

        public Commands.Command SaveChanges { get; private set; }

        public void Show(Action<object> saveAction, T item)
        {
            Item = item;
            this.saveAction = saveAction;
            ShowDialogOfType(editorWindowType, out window, this);
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
        {
            this.editorWindowType = editorWindowType;
            SaveChanges = new Commands.Command(OnSaveChanges, CanSave);
        }

        private bool CanSave()
        {
            var context = new ValidationContext(Item, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(Item, context, results))
                return true;
            return false;
        }

        private void OnSaveChanges(object parameter)
        {
            saveAction(Item);
            window.Close();
        }
    }
}
