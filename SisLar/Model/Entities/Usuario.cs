using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SisLar.Model.Entities
{
    [Serializable]
    public class Usuario : INotifyPropertyChanged
    {
        #region ::: Membros
        protected string _nome;
        protected int? _id;
        protected string _login;
        protected string _senha;
        protected long _handle;
        public virtual event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region ::: Construtor

        #endregion

        #region ::: Propriedades públicas

        public virtual string Nome
        {
            get { return _nome; }
            set { if (value != this._nome) { _nome = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Nome")); } }
        }
        public virtual int? Id
        {
            get { return _id; }
            set { if (value != this._id) { _id = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Id")); } }
        }
        public virtual string Login
        {
            get { return _login; }
            set { if (value != this._login) { _login = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Login")); } }
        }
        public virtual string Senha
        {
            get { return _senha; }
            set { if (value != this._senha) { _senha = value; this.PropertyChanged(this, new PropertyChangedEventArgs("Senha")); } }
        }
        public virtual long Handle
        {
            get { return _handle; }
        }

        #endregion
    }
}
