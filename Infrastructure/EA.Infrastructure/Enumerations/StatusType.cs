using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Enumerations
{
    public enum StatusType
    {
        [Description("Silinmiş")]
        Deleted = -1,

        [Description("Pasif")]
        NotAvailable = 0,

        [Description("Aktif")]
        Available = 1
    }
}
