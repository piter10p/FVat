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
    enum Unit
    {
        [Description("Brak jednostki")]
        NoUnit = 0,
        [Description("m")]
        Meter = 1,
        [Description("m^2")]
        Meter2 = 2,
        [Description("m^3")]
        Meter3 = 3,
        [Description("g")]
        Gramme = 4,
        [Description("kg")]
        Kilogramme = 5,
        [Description("t")]
        Tone = 6,
        [Description("szt.")]
        Apiece = 7
    }
}
