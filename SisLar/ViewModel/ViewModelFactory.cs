using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisLar.Model;

namespace SisLar.ViewModel
{
    public class ViewModelFactory
    {
        //TelaPrincipal
        private static MainViewModel _mainViewModel;

        private static CadastroFuncionarioViewModel _cadastroDepartamentoViewModel;

        public ViewModelFactory()
        {
            NHibernateHelper.InitializeSessionFactory();
        }
        public MainViewModel MainViewModel
        {
            get
            {
                _mainViewModel = new MainViewModel();
                return _mainViewModel;
            }
        }
        public CadastroFuncionarioViewModel CadastroDepartamentoViewModel
        {
            get
            {
                _cadastroDepartamentoViewModel = new CadastroFuncionarioViewModel();
                return _cadastroDepartamentoViewModel;
            }
        }
    }
}
