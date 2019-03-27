﻿using FVat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    class VATsViewModel : ListViewModel<VAT>
    {
        public VATsViewModel()
            : base()
        {
            ShowVATItemsWindow = new Commands.Command(OnShowVATItemsWindow);
            ShowVATEntitiesWindow = new Commands.Command(OnShowVATEntitiesWindow);
        }

        public Type VATItemsWindowType { get; set; }
        public Type VATEntitiesWindowType { get; set; }

        public Commands.Command ShowVATItemsWindow { get; private set; }
        public Commands.Command ShowVATEntitiesWindow { get; private set; }

        protected override async void OnAddAsync(object parameter)
        {
            try
            {
                if (parameter == null)
                    throw new ArgumentNullException();

                await DAL.VATsManager.AddNewVATAsync(parameter as VAT);
                UpdateList();
            }
            catch { throw; }
        }

        protected override async void OnModifyAsync(object parameter)
        {
            
        }

        protected override async void OnDeleteAsync(object parameter)
        {
            try
            {
                if (SelectedItem == null)
                    throw new Exception("Selected vat is null");

                await DAL.VATsManager.RemoveVATAsync(SelectedItem);
                UpdateList();
            }
            catch { throw; }
        }

        protected override void UpdateList()
        {
            ItemsList = new ObservableCollection<VAT>(DAL.VATsManager.GetEntities());
        }

        private void OnShowVATItemsWindow(object parameter)
        {
            Models.IClosable closable;
            ShowDialogOfType(VATItemsWindowType, out closable);
        }

        private void OnShowVATEntitiesWindow(object parameter)
        {
            Models.IClosable closable;
            ShowDialogOfType(VATEntitiesWindowType, out closable);
        }
    }
}
