using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SisLar.Model.Entities;

namespace SisLar.Model.Mappings
{
    public class AnexoMapping : ClassMap<Anexo>
    {
        //Constructor
        public AnexoMapping()
        {
            Table("Anexo");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Identity();

            Map(x => x.Descricao, "DESCRICAO");

            Map(x => x.Arquivo, "ARQUIVO");

            Map(x => x.Observacao, "OBSERVACAO");

            Map(x => x.DataImportacao, "DATAIMPORTACAO");

            Map(x => x.Aluno, "ALUNO");
        }
    }
}
