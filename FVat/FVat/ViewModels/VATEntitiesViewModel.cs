using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.ViewModels
{
    class VATEntitiesViewModel
    {
        public ObservableCollection<VATEntity> VATEntities
        {
            get
            {
                return new ObservableCollection<VATEntity>(DAL.VATEntitiesManager.GetEntities());
            }
        }
    }
}
