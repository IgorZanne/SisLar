using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    [Serializable]
    public class Usuario
    {
        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        public virtual long Handle { get; set; }

        [Description("Nome")]
        public virtual string Nome { get; set; }

        [Description("Código")]
        public virtual int? Codigo { get; set; }

        [Description("Login")]
        public virtual string Login { get; set; }

        [Description("Senha")]
        public virtual string Senha { get; set; }

        #endregion
    }
}
