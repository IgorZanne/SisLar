using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    public class Produto
    {
        public virtual long Handle { get; set; }

        [DisplayName("Tipo")]
        public virtual string Tipo { get; set; }

        [DisplayName("Descrição")]
        public virtual string Descricao { get; set; }

        [DisplayName("Marca")]
        public virtual string Marca { get; set; }

        [DisplayName("Unidade")]
        public virtual DateTime Unidade { get; set; }

        [DisplayName("Quantidade")]
        public virtual string Quantidade { get; set; }

        //TODO: Criar campo de data de validade
    }
}
