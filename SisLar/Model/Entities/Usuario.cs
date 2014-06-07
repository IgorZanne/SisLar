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

        public virtual string Nome { get; set; }
        public virtual int? Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual long Handle { get; set; }

        #endregion
    }
}
