using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Enum
{
    public enum PeriodoEnum
    {
        [Description("Manhã")]
        Manha = 0,

        [Description("Tarde")]
        Tarde = 1,

        [Description("Noite")]
        Noite = 2
    }
}
