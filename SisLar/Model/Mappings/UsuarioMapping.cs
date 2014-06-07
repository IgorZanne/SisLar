using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SisLar.Model.Entities;

namespace SisLar.Model.Mappings
{
    class UsuarioMapping : ClassMap<Usuario>
    {
        //Constructor
        public UsuarioMapping()
        {
            Table("SIS_USUARIO");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Assigned();

            Map(x => x.Id, "ID");

            Map(x => x.Login, "LOGIN");

            Map(x => x.Nome, "NOME");

            Map(x => x.Senha, "SENHA");

        }
    }
}
