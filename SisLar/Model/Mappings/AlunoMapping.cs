using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SisLar.Model.Enum;

namespace SisLar.Model.Entities
{
    public class AlunoMapping : ClassMap<Aluno>
    {
        //Constructor
        public AlunoMapping()
        {
            Table("Aluno");

            Id(x => x.Handle, "HANDLE")
                .GeneratedBy.Identity();

            Map(x => x.Matricula, "MATRICULA");

            Map(x => x.Telefone, "TELEFONE");

            Map(x => x.DataNascimento, "DATANASCIMENTO");

            Map(x => x.Nome, "NOME");

            Map(x => x.Turma, "TURMA");

            Map(x => x.Sexo, "SEXO").CustomType(typeof(SexoEnum)).Nullable();

            Map(x => x.DataMatricula, "DATAMATRICULA");

            Map(x => x.Endereco, "ENDERECO");

            Map(x => x.Bairro, "BAIRRO");

            Map(x => x.Escola, "ESCOLA");

            Map(x => x.ProgGoverno, "PROGGOVERNO");

            Map(x => x.AnoEscolar, "ANOESCOLAR");

            Map(x => x.EmpresaTrabMae, "EMPRESATRABMAE");

            Map(x => x.EnderecoTrabMae, "ENDERECOTRABMAE");

            Map(x => x.BairroEmpresaTrabMae, "BAIRROEMPRESATRABMAE");

            Map(x => x.TelefoneEmpresaTrabMae, "TELEFONEEMPRESATRABMAE");

            Map(x => x.EmpresaTrabPai, "EMPRESATRABPAI");

            Map(x => x.EnderecoTrabPai, "ENDERECOTRABPAI");

            Map(x => x.BairroEmpresaTrabPai, "BAIRROEMPRESATRABPAI");

            Map(x => x.TelefoneEmpresaTrabPai, "TELEFONEEMPRESATRABPAI");

            Map(x => x.EmpresaTrabResp, "EMPRESATRABRESP");

            Map(x => x.EnderecoTrabResp, "ENDERECOTRABRESP");

            Map(x => x.BairroEmpresaTrabResp, "BAIRROEMPRESATRABRESP");

            Map(x => x.TelefoneEmpresaTrabResp, "TELEFONEEMPRESATRABRESP");

            Map(x => x.TipoResponsavel, "TIPORESPONSAVEL");

            Map(x => x.Periodo, "PERIODO");

            Map(x => x.CaminhoFoto, "CAMINHOFOTO");

            Map(x => x.Observacoes, "OBSERVACOES");
        }
    }
}
