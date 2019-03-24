using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    class VATEntitiesEditorViewModel: BaseViewModel
    {
        private VATEntity _VATEntity;

        public Commands.Command SaveChanges { get; private set; }

        public string Name
        {
            get
            {
                return VATEntity.Name;
            }

            set
            {
                VATEntity.Name = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string Street
        {
            get
            {
                return VATEntity.Street;
            }

            set
            {
                VATEntity.Street = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string ParcelNumber
        {
            get
            {
                return VATEntity.ParcelNumber;
            }

            set
            {
                VATEntity.ParcelNumber = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string PostCode
        {
            get
            {
                return VATEntity.PostCode;
            }

            set
            {
                VATEntity.PostCode = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public string PostCity
        {
            get
            {
                return VATEntity.PostCity;
            }

            set
            {
                VATEntity.PostCity = value;
                SaveChanges.RaiseCanExecuteChanged();
            }
        }

        public VATEntity VATEntity
        {
            get
            {
                return _VATEntity;
            }

            set
            {
                _VATEntity = value;
            }
        }

        public VATEntitiesEditorViewModel(Action<object> saveAction)
        {
            _VATEntity = new VATEntity();
            SaveChanges = new Commands.Command(saveAction, CanSave);
        }

        public VATEntitiesEditorViewModel(Action<object> saveAction, VATEntity entity)
        {
            _VATEntity = entity;
            SaveChanges = new Commands.Command(saveAction, CanSave);
        }

        private bool CanSave()
        {
            var context = new ValidationContext(VATEntity, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(VATEntity, context, results))
                return true;
            return false;
        }
    }
}
