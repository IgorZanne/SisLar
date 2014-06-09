using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    public class Aluno
    {
        public virtual long Handle { get; set; }

        [DisplayName("Matrícula")]
        public virtual string Matricula { get; set; }

        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [DisplayName("Endereço")]
        public virtual string Endereco { get; set; }

        [DisplayName("Data de nascimento")]
        public virtual DateTime DataNascimento { get; set; }

        [DisplayName("RG")]
        public virtual string Rg { get; set; }

        [DisplayName("Sexo")]
        public virtual string Sexo { get; set; }

        [DisplayName("Data da matrícula")]
        public virtual DateTime DataMatricula { get; set; }
    }
}
