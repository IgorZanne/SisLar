using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SisLar.Model.Enum;

namespace SisLar.Model.Entities
{
    public class Aluno
    {
        public virtual long Handle { get; set; }

        [DisplayName("Matrícula")]
        public virtual long Matricula { get; set; }

        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [DisplayName("Telefone")]
        public virtual string Telefone { get; set; }

        [DisplayName("Endereço")]
        public virtual string Endereco { get; set; }

        [DisplayName("Bairro")]
        public virtual string Bairro { get; set; }

        [DisplayName("Data de nascimento")]
        public virtual DateTime DataNascimento { get; set; }

        [DisplayName("Turma")]
        public virtual string Turma { get; set; }

        [DisplayName("Sexo")]
        public virtual SexoEnum? Sexo { get; set; }

        [DisplayName("Data da matrícula")]
        public virtual DateTime DataMatricula { get; set; }

        [DisplayName("Escola")]
        public virtual String Escola { get; set; }

        [DisplayName("Participa de programa do governo")]
        public virtual Boolean? ProgGoverno { get; set; }

        [DisplayName("Série")]
        public virtual String AnoEscolar { get; set; }

        [DisplayName("Empresa onde mãe trabalha")]
        public virtual String EmpresaTrabMae { get; set; }

        [DisplayName("Endereço da empresa onde mãe trabalha")]
        public virtual String EnderecoTrabMae { get; set; }

        [DisplayName("Bairro da empresa onde mãe trabalha")]
        public virtual String BairroEmpresaTrabMae { get; set; }

        [DisplayName("Telefone da empresa onde mãe trabalha")]
        public virtual String TelefoneEmpresaTrabMae { get; set; }

        [DisplayName("Empresa onde pai trabalha")]
        public virtual String EmpresaTrabPai { get; set; }

        [DisplayName("Endereço da empresa onde pai trabalha")]
        public virtual String EnderecoTrabPai { get; set; }

        [DisplayName("Bairro da empresa onde pai trabalha")]
        public virtual String BairroEmpresaTrabPai { get; set; }

        [DisplayName("Telefone da empresa onde pai trabalha")]
        public virtual String TelefoneEmpresaTrabPai { get; set; }

        [DisplayName("Empresa onde responsável trabalha")]
        public virtual String EmpresaTrabResp { get; set; }

        [DisplayName("Endereço da empresa onde responsável trabalha")]
        public virtual String EnderecoTrabResp { get; set; }

        [DisplayName("Bairro da empresa onde responsável trabalha")]
        public virtual String BairroEmpresaTrabResp { get; set; }

        [DisplayName("Telefone da empresa onde responsável trabalha")]
        public virtual String TelefoneEmpresaTrabResp { get; set; }

        [DisplayName("Responsável")]
        public virtual TipoResponsavelEnum TipoResponsavel { get; set; }

        [DisplayName("Período")]
        public virtual PeriodoEnum? Periodo { get; set; }

        [DisplayName("Foto")]
        public virtual string CaminhoFoto { get; set; }

        [DisplayName("Observações")]
        public virtual string Observacoes { get; set; }
    }
}
