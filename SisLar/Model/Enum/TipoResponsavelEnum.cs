using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Enum
{
    [Flags]
    public enum TipoResponsavelEnum
    {
        [Description("Nenhum")]
        Nenhum = 0,

        [Description("Mãe")]
        Mae = 1,

        [Description("Pai")]
        Pai = 2,

        [Description("Avós")]
        Avo = 4,

        [Description("Tio")]
        Tio = 8,

        [Description("Outros")]
        Outros = 16
    }
}
