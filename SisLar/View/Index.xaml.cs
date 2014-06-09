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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SisLar.Model.Enum;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        private TipoCadastroEnum tipoCadastro { get; set; }
        private Frame frameTelaPrincipal { get; set; }

        public Index(Frame frameTelaPrincipal, TipoCadastroEnum tipoCadastro)
        {
            InitializeComponent();
            this.tipoCadastro = tipoCadastro;
            this.frameTelaPrincipal = frameTelaPrincipal;
            edtFiltro.Focus();
            switch (tipoCadastro)
            {
                case TipoCadastroEnum.Aluno:
                    gbContainer.Header = "Alunos";
                    break;
                case TipoCadastroEnum.Funcionario:
                    gbContainer.Header = "Funcionários";
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    gbContainer.Header = "Contas a pagar";
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    gbContainer.Header = "Contas a receber";
                    break;
                case TipoCadastroEnum.Produto:
                    gbContainer.Header = "Produtos";
                    break;
                case TipoCadastroEnum.Usuario:
                    gbContainer.Header = "Usuários";
                    break;
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            switch (this.tipoCadastro)
            {
                case TipoCadastroEnum.Aluno:
                    var novoAluno = new CadastroAluno(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoAluno);
                    break;
                case TipoCadastroEnum.Funcionario:
                    var novoFuncionario = new CadastroFuncionario(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoFuncionario);
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    var novoLancamentoPagar = new Contas(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoLancamentoPagar);
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    var novoLancamentoReceber = new Contas(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoLancamentoReceber);
                    break;
                case TipoCadastroEnum.Produto:
                    var novoProduto = new CadastroProduto(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoProduto);
                    break;
                case TipoCadastroEnum.Usuario:
                    var novoUsuario = new CadastroUsuario(frameTelaPrincipal);
                    frameTelaPrincipal.Navigate(novoUsuario);
                    break;
                default:

                    break;
            }
        }
    }
}
