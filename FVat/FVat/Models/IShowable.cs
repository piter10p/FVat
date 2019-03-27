using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    interface IShowable
    {
        void Show();
        Nullable<bool> ShowDialog();
    }
}
