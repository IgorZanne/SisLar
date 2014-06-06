using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using SisLar.Model.Entities;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Windows;
using System.Collections.ObjectModel;
using SisLar.Model.Repository;

namespace SisLar.ViewModel
{
    public class CadastroFuncionarioViewModel : ViewModelBase
    {
        #region ::: Variáveis
 
        private Funcionario _funcionarioAtual;
        public Funcionario FuncionarioAtual
        {
            get { return _funcionarioAtual; }
            set
            {
                if (value != _funcionarioAtual)
                {
                    _funcionarioAtual = value;
                    RaisePropertyChanged("FuncionarioAtual");
                }
            }
        }
 
        private int _codFuncionario;
        public int CodFuncionario
        {
            get { return _codFuncionario; }
            set
            {
                if (value != _codFuncionario)
                {
                    _codFuncionario = value;
                    RaisePropertyChanged("CodFuncionario");
                }
            }
        }
 
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != _nome)
                {
                    _nome = value;
                    RaisePropertyChanged("Nome");
                }
            }
        }
 
        private int? _numero;
        public int? Numero
        {
            get { return _numero; }
            set
            {
                if (value != _numero)
                {
                    _numero = value;
                    RaisePropertyChanged("Numero");
                }
            }
        }
 
        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (value != _descricao)
                {
                    _descricao = value;
                    RaisePropertyChanged("Descricao");
                }
            }
        }
 
        private ObservableCollection<Funcionario> _funcionarioList;
        public ObservableCollection<Funcionario>  FuncionarioList
        {
            get { return _funcionarioList; }
            set
            {
                if (value != _funcionarioList)
                {
                    _funcionarioList = value;
                    RaisePropertyChanged("FuncionarioList");
                }
            }
        }
 
        #endregion Variáveis
 
        #region ::: Initialization
 
        public CadastroFuncionarioViewModel()
        {
            if (!IsInDesignMode)
            {
                FuncionarioList = new ObservableCollection<Funcionario>();
                AtualizaDadosNaTela();
            }
        }
 
        #endregion End Initialization
 
        #region ::: Commands
 
        private ICommand _newFuncionarioCommand;
        public ICommand NewFuncionarioCommand
        {
            get
            {
                return _newFuncionarioCommand ?? (_newFuncionarioCommand = new RelayCommand(New));
            }
        }
 
        private ICommand _saveFuncionarioCommand;
        public ICommand SaveFuncionarioCommand
        {
            get
            {
                return _saveFuncionarioCommand ?? (_saveFuncionarioCommand = new RelayCommand(Save));
            }
        }
 
        private ICommand _deleteFuncionarioCommand;
        public ICommand DeleteFuncionarioCommand
        {
            get
            {
                return _deleteFuncionarioCommand ?? (_deleteFuncionarioCommand = new RelayCommand(Delete));
            }
        }
 
        #endregion End Commands
 
        #region ::: Logic

        public IRepositorio<Funcionario> repFuncionario;
 
        private void AtualizaDadosNaTela()
        {
            FuncionarioList.Clear();
            FuncionarioAtual = null;
            IList tempListD = repFuncionario.RetornaTodos().ToList();
 
            foreach (Funcionario item in tempListD)
            {
                FuncionarioList.Add(item);
            }
        }
 
        public void New()
        {
            FuncionarioAtual = new Funcionario();
        }
 
        public void Save()
        {
            try
            {
                if (FuncionarioAtual != null && repFuncionario.Altera(FuncionarioAtual))
                {
                    AtualizaDadosNaTela();
                    MessageBox.Show("Salvo com sucesso");
                }
                else{MessageBox.Show("Ocorreu um erro ao salvar");}
            }
            catch (Exception) { MessageBox.Show("Ocorreu uma exceção ao salvar"); }
        }
 
        public void Delete()
        {
            try
            {
                if (repFuncionario.Excluir(FuncionarioAtual))
                {
                    AtualizaDadosNaTela();
                    MessageBox.Show("Excluido com sucesso");
              }
            }
           catch (Exception) { MessageBox.Show("Ocorreu uma exceção ao Excluir"); }
        }
 
        #endregion End Logic
    }
}
