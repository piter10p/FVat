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
    enum PaymentMethod
    {
        [Description("Nie dotyczy")]
        No = 0,
        [Description("Gotówka")]
        Cash = 1,
        [Description("Przelew")]
        BankTransfer = 2,
        [Description("Online")]
        Online = 3,
        [Description("Przy odbiorze")]
        WhenCollecting = 4
    }
}
