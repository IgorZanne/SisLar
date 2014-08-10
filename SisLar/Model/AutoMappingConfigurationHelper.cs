using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using SisLar.Model.Entities;

namespace SisLar.Model
{
    public class AutoMappingConfigurationHelper : DefaultAutomappingConfiguration
    {
        IList<Type> _objectsToMap = new List<Type>()
        {
            // whitelisted objects to map
            typeof(Aluno), 
            typeof(Anexo), 
            typeof(Funcionario), 
            typeof(Lancamento), 
            typeof(Produto), 
            typeof(Usuario)
        };

        public override bool ShouldMap(Type type) 
        { 
            return _objectsToMap.Any(x => x == type); 
        }
        public override bool IsId(Member member)
        {
            return member.Name == "Handle";
        }
    }
}
