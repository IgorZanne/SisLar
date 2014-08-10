using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    public class Anexo
    {
        public virtual long Handle { get; set; }

        [DisplayName("Descrição")]
        public virtual String Descricao { get; set; }

        [DisplayName("Arquivo")]
        public virtual String Arquivo { get; set; }

        [DisplayName("Observação")]
        public virtual String Observacao { get; set; }

        [DisplayName("Data importação")]
        public virtual DateTime DataImportacao { get; set; }

        [DisplayName("Aluno")]
        public virtual long Aluno { get; set; }
    }
}
