using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernate;

namespace SisLar.Model.Entities
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Table("Usuario");
            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Identity();

            Map(x => x.Codigo, "CODIGO");

            Map(x => x.Login, "LOGIN")
                .Length(50);

            Map(x => x.Nome, "NOME")
                .Length(100);

            Map(x => x.Senha, "SENHA")
                .Length(50);

        }
    }
}
