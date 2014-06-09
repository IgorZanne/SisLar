using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace SisLar.Model.Entities
{
    public class LancamentoMapping : ClassMap<Lancamento>
    {
        public LancamentoMapping()
        {
            Table("Lancamento");

            Id(x => x.Handle, "HANDLE")
                    .GeneratedBy.Assigned();

            Map(x => x.DataInclusao, "DATAINCLUSAO");

            Map(x => x.DataPagamento, "DATAPAGAMENTO");

            Map(x => x.DataVencimento, "DATAVENCIMENTO");

            Map(x => x.Observacoes, "OBSERVACOES");

            Map(x => x.Tipo, "TIPO");

            Map(x => x.Valor, "VALOR");

            Map(x => x.ValorPago, "VALORPAGO");
        }
    }
}
