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
    enum VATRate
    {
        [Description("23%")]
        Rate23 = 0,
        [Description("8%")]
        Rate8 = 1,
        [Description("5%")]
        Rate5 = 2,
        [Description("0%")]
        Rate0 = 3,
        [Description("zw.")]
        RateZW = 4
    }
}
