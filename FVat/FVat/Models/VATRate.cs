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
    //All values represents exact VAT value. Except ZW
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    enum VATRate
    {
        [Description("23%")]
        Rate23 = 23,
        [Description("8%")]
        Rate8 = 8,
        [Description("5%")]
        Rate5 = 5,
        [Description("0%")]
        Rate0 = 0,
        [Description("zw.")]
        RateZW = 100
    }
}
