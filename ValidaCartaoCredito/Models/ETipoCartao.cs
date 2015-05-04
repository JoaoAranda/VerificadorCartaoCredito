using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ValidaCartaoCredito.Models
{
    public enum ETipoCartao : byte
    {
        [Description("DESCONHECIDO")]
        Desconhecido = 0,

        [Description("AMEX")]
        Amex = 2,

        [Description("DISCOVER")]
        Discover = 4,

        [Description("MASTERCARD")]
        MasterCard = 8,

        [Description("VISA")]
        Visa = 16
    }
}