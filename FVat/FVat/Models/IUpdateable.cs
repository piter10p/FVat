using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    interface IUpdateable<T>
    {
        void Update(T source);
    }
}
