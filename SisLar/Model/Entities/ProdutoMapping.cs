using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace SisLar.Model.Entities
{
    public class ProdutoMapping : ClassMap<Produto>
    {
        //Constructor
        public ProdutoMapping()
        {
            Table("Produto");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Identity();

            Map(x => x.Descricao, "DESCRICAO");

            Map(x => x.Marca, "MARCA");

            Map(x => x.Quantidade, "QUANTIDADE");

            Map(x => x.Tipo, "TIPO");

            Map(x => x.Unidade, "UNIDADE");
        }
    }
}
