using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    [Serializable]
    public class Funcionario : INotifyPropertyChanged
    {
        #region ::: Membros
		protected string _nome;
		protected int? _id;
        protected DateTime? _dataNascimento;
		protected string _setor;
		protected string _endereco;
		protected DateTime? _dataAdmissao;
		protected DateTime? _dataDemissao;
        protected string _telefone;
        protected string _celular;
        protected string _sexo;
        protected string _carteira;
        protected long _handle;
        public virtual event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        public  virtual string Nome
		{
			get { return _nome; }
            set { if (value != this._nome) { _nome = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Nome")); } }
		}
        public  virtual int? Id
		{
			get { return _id; }
            set { if (value != this._id) { _id = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Id")); } }
		}
        public  virtual DateTime? DataNascimento
		{
			get { return _dataNascimento; }
            set { if (value != this._dataNascimento) { _dataNascimento = value; this.PropertyChanged(this, new PropertyChangedEventArgs("DataNascimento")); } }
		}
        public  virtual string Setor
		{
			get { return _setor; }
            set { if (value != this._setor) { _setor = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Setor")); } }
		}
        public  virtual string Endereco
		{
			get { return _endereco; }
            set { if (value != this._endereco) { _endereco = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Endereco")); } }
		}
        public  virtual DateTime? DataAdmissao
		{
			get { return _dataAdmissao; }
            set { if (value != this._dataAdmissao) { _dataAdmissao = value; this.PropertyChanged(this, new PropertyChangedEventArgs("DataAdmissao")); } }
		}
        public  virtual DateTime? DataDemissao
		{
			get { return _dataDemissao; }
            set { if (value != this._dataDemissao) { _dataDemissao = value; this.PropertyChanged(this, new PropertyChangedEventArgs("DataDemissao")); } }
		}
        public  virtual string Telefone
		{
			get { return _telefone; }
            set { if (value != this._telefone) { _telefone = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Telefone")); } }
		}
        public  virtual string Celular
		{
			get { return _celular; }
            set { if (value != this._celular) { _celular = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Celular")); } }
		}
        public  virtual string Sexo
		{
			get { return _sexo; }
            set { if (value != this._sexo) { _sexo = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Sexo")); } }
		}
        public  virtual string Carteira
		{
			get { return _carteira; }
            set { if (value != this._carteira) { _carteira = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Carteira")); } }
		}
        public  virtual long Handle
		{
			get { return _handle; }
		}

        #endregion
    }
}
