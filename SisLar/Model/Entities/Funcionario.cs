﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SisLar.Model.Enum;

namespace SisLar.Model.Entities
{
    [Serializable]
    public class Funcionario
    {
        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        public virtual long Handle { get; set; }

        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [DisplayName("Código")]
        public virtual int? Codigo { get; set; }

        [DisplayName("Data de nascimento")]
        public virtual DateTime? DataNascimento { get; set; }

        [DisplayName("Setor")]
        public virtual string Setor { get; set; }

        [DisplayName("Endereço")]
        public virtual string Endereco { get; set; }

        [DisplayName("Data de admissão")]
        public virtual DateTime? DataAdmissao { get; set; }

        [DisplayName("Data da demissão")]
        public virtual DateTime? DataDemissao { get; set; }

        [DisplayName("Telefone")]
        public virtual string Telefone { get; set; }

        [DisplayName("Celular")]
        public virtual string Celular { get; set; }

        [DisplayName("Sexo")]
        public virtual SexoEnum? Sexo { get; set; }

        [DisplayName("Carteira")]
        public virtual string Carteira { get; set; }

        [DisplayName("Bairro")]
        public virtual string Bairro { get; set; }

        #endregion
    }
}
