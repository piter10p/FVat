using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    sealed class VATEntitiesEditorViewModel: EditorViewModel<VATEntity>
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
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string Street
        {
            get
            {
                return Item.Street;
            }

            set
            {
                Item.Street = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string ParcelNumber
        {
            get
            {
                return Item.ParcelNumber;
            }

            set
            {
                Item.ParcelNumber = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string PostCode
        {
            get
            {
                return Item.PostCode;
            }

            set
            {
                Item.PostCode = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string PostCity
        {
            get
            {
                return Item.PostCity;
            }

            set
            {
                Item.PostCity = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public VATEntitiesEditorViewModel(Type editorWindowType)
            :base(editorWindowType)
        {
        }
    }
}
