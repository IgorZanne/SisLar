using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace SisLar.Model.Entities
{
    public class AlunoMapping : ClassMap<Aluno>
    {
        //Constructor
        public AlunoMapping()
        {
            Table("Aluno");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Assigned();

            Map(x => x.Matricula, "MATRICULA");

            Map(x => x.DataNascimento, "DATANASCIMENTO");

            Map(x => x.Nome, "NOME");

            Map(x => x.Rg, "RG");

            Map(x => x.Sexo, "Sexo");

            Map(x => x.DataMatricula, "DATAMATRICULA");

            Map(x => x.Endereco, "ENDERECO");
        }
    }
}
