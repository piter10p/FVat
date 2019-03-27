using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    class ItemSelectControlViewModel: BaseViewModel
    {
        public Commands.Command SelectionCommand { get; private set; }
        public BasicEntity Entity { get; set;}

        public ItemSelectControlViewModel(BasicEntity entity)
        {
            Entity = entity;
            SelectionCommand = new Commands.Command(CallSelectionCommand);
        }

        private void CallSelectionCommand(object parameter)
        {
        }
    }
}
