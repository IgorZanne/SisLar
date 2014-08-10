using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SisLar.Model.Enum;

namespace SisLar.Model.Entities
{
    public class Lancamento
    {
        public virtual long Handle { get; set; }

        [DisplayName("Tipo")]
        public virtual TipoLancamentoEnum Tipo { get; set; }

        [DisplayName("Valor")]
        public virtual Double Valor { get; set; }

        [DisplayName("Data de pagamento")]
        public virtual DateTime? DataPagamento { get; set; }

        [DisplayName("Data de inclusão")]
        public virtual DateTime DataInclusao { get; set; }

        [DisplayName("Data de vencimento")]
        public virtual DateTime? DataVencimento { get; set; }

        [DisplayName("Observações")]
        public virtual string Observacao { get; set; }

        [DisplayName("Valor pago")]
        public virtual Double ValorPago { get; set; }
    }
}
