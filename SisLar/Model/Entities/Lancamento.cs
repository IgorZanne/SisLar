using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    public class Lancamento
    {
        public virtual long Handle { get; set; }

        [DisplayName("Tipo")]
        public virtual string Tipo { get; set; }

        [DisplayName("Valor")]
        public virtual string Valor { get; set; }

        [DisplayName("Data de pagamento")]
        public virtual string DataPagamento { get; set; }

        [DisplayName("Data de inclusão")]
        public virtual DateTime DataInclusao { get; set; }

        [DisplayName("Data de vencimento")]
        public virtual string DataVencimento { get; set; }

        [DisplayName("Observações")]
        public virtual string Observacao { get; set; }

        [DisplayName("Valor pago")]
        public virtual string ValorPago { get; set; }
    }
}
