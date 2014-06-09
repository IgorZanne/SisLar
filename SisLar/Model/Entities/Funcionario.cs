using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    [Serializable]
    public class Funcionario
    {
        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        [Description("Nome")]
        public virtual string Nome { get; set; }

        [Description("Código")]
        public virtual int? Codigo { get; set; }

        [Description("Data de nascimento")]
        public virtual DateTime? DataNascimento { get; set; }

        [Description("Setor")]
        public virtual string Setor { get; set; }

        [Description("Endereço")]
        public virtual string Endereco { get; set; }

        [Description("Data de admissão")]
        public virtual DateTime? DataAdmissao { get; set; }

        [Description("Data da demissão")]
        public virtual DateTime? DataDemissao { get; set; }

        [Description("Telefone")]
        public virtual string Telefone { get; set; }

        [Description("Celular")]
        public virtual string Celular { get; set; }

        [Description("Sexo")]
        public virtual string Sexo { get; set; }

        [Description("Carteira")]
        public virtual string Carteira { get; set; }

        public virtual long Handle { get; set; }

        #endregion
    }
}
