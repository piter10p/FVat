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

        public Commands.Command SaveChanges { get; private set; }

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

        public EditorViewModel(Action<object> saveAction, T item)
        {
            _item = item;
            SaveChanges = new Commands.Command(saveAction, CanSave);
        }

        private bool CanSave()
        {
            var context = new ValidationContext(Item, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(Item, context, results))
                return true;
            return false;
        }
    }
}
