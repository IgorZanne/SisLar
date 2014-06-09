using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SisLar.Model.Enum;
using System.Windows.Navigation;
using SisLar.Model.Entities;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        //public IRepositorio<Usuario> repUsuario;
        private TipoCadastroEnum? indexAcessado { get; set; }
        private Usuario UsuarioAcesso;
        private Index pageIndex;

        public TelaPrincipal(Usuario UsuarioAcesso)
        {
            InitializeComponent();
            this.UsuarioAcesso = UsuarioAcesso;
            this.lblRecepcao.Content = "Olá " + UsuarioAcesso.Nome + "!";
            frameTelaPrincipal.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void alunoCadastro_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.Aluno;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.Aluno);
            frameTelaPrincipal.Navigate(pageIndex);
        }

        private void funcionariosCadastro_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.Funcionario;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.Funcionario);
            frameTelaPrincipal.Navigate(pageIndex);
        }

        private void estoqueProdutos_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.Produto;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.Produto);
            frameTelaPrincipal.Navigate(pageIndex);
        }

        private void contasPagar_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.LancamentoPagar;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.LancamentoPagar);
            frameTelaPrincipal.Navigate(pageIndex);
        }

        private void contasReceber_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.LancamentoReceber;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.LancamentoReceber);
            frameTelaPrincipal.Navigate(pageIndex);
        }

        private void usuarioCadastro_Click(object sender, RoutedEventArgs e)
        {
            indexAcessado = TipoCadastroEnum.Usuario;
            pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.Usuario);
            frameTelaPrincipal.Navigate(pageIndex);
        }
    }
}
