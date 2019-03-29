using FVat.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    //Don't modify unless you know, what you're doing
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    enum DeliveryMethod
    {
        [Description("Nie dotyczy")]
        No = 0,
        [Description("Odbiór osobisty")]
        PersonalCollection = 1,
        [Description("Kurier")]
        Courier = 2,
    }
}
