using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace SisLar.Model.Entities
{
    class FuncionarioMapping : ClassMap<Funcionario>
    {
        //Constructor
        public FuncionarioMapping()
        {
            Table("SIS_FUNCIONARIO");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Assigned();

            Map(x => x.Codigo, "CODIGO");

            Map(x => x.DataNascimento, "DATANASCIMENTO");

            Map(x => x.Setor, "SETOR");

            Map(x => x.Endereco, "ENDERECO");

            Map(x => x.DataAdmissao, "DATAADMISSAO");

            Map(x => x.DataDemissao, "DATADEMISSAO");

            Map(x => x.Telefone, "TELEFONE");

            Map(x => x.Celular, "CELULAR");

            Map(x => x.Carteira, "CARTEIRA");

        }
    }
}
