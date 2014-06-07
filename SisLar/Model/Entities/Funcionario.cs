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
        #region ::: Membros
        #endregion

        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        public virtual string Nome { get; set; }
        public virtual int? Id { get; set; }
        public virtual DateTime? DataNascimento { get; set; }
        public virtual string Setor { get; set; }
        public virtual string Endereco { get; set; }
        public virtual DateTime? DataAdmissao { get; set; }
        public virtual DateTime? DataDemissao { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string Carteira { get; set; }
        public virtual long Handle { get; set; }

        #endregion
    }
}
