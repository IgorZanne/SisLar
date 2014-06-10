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
using System.Reflection;
using System.ComponentModel;
using SisLar.Model.Entities;
using SisLar.Model.Repository;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        private TipoCadastroEnum tipoCadastro { get; set; }
        private Frame frameTelaPrincipal { get; set; }
        private List<String> listaPropriedades { get; set; }
        private IRepositorio<Aluno> repAluno { get; set; }
        private IRepositorio<Funcionario> repFuncionario { get; set; }
        private IRepositorio<Lancamento> repLancamento { get; set; }
        private IRepositorio<Produto> repProduto { get; set; }
        private IRepositorio<Usuario> repUsuario { get; set; }

        public Index(Frame frameTelaPrincipal, TipoCadastroEnum tipoCadastro)
        {
            InitializeComponent();
            this.tipoCadastro = tipoCadastro;
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.listaPropriedades = new List<string>();
            edtFiltro.Focus();
            switch (tipoCadastro)
            {
                case TipoCadastroEnum.Aluno:
                    gbContainer.Header = "Alunos";
                    cbFiltro.ItemsSource = GetListaPropriedades<Aluno>();
                    this.repAluno = new Repositorio<Aluno>();
                    GridResultados.ItemsSource = repAluno.RetornaTodos();
                    break;
                case TipoCadastroEnum.Funcionario:
                    gbContainer.Header = "Funcionários";
                    cbFiltro.ItemsSource = GetListaPropriedades<Funcionario>();
                    this.repFuncionario = new Repositorio<Funcionario>();
                    GridResultados.ItemsSource = repFuncionario.RetornaTodos();
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    gbContainer.Header = "Contas a pagar";
                    cbFiltro.ItemsSource = GetListaPropriedades<Lancamento>();
                    this.repLancamento = new Repositorio<Lancamento>();
                    GridResultados.ItemsSource = repLancamento.Consulta(e => e.Tipo.Equals("P"));
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    gbContainer.Header = "Contas a receber";
                    cbFiltro.ItemsSource = GetListaPropriedades<Lancamento>();
                    this.repLancamento = new Repositorio<Lancamento>();
                    GridResultados.ItemsSource = repLancamento.Consulta(e => e.Tipo.Equals("R"));
                    break;
                case TipoCadastroEnum.Produto:
                    gbContainer.Header = "Produtos";
                    cbFiltro.ItemsSource = GetListaPropriedades<Produto>();
                    this.repProduto = new Repositorio<Produto>();
                    GridResultados.ItemsSource = repProduto.RetornaTodos();
                    break;
                case TipoCadastroEnum.Usuario:
                    gbContainer.Header = "Usuários";
                    cbFiltro.ItemsSource = GetListaPropriedades<Usuario>();
                    this.repUsuario = new Repositorio<Usuario>();
                    GridResultados.ItemsSource = repUsuario.RetornaTodos();
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
                    var novoLancamentoPagar = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Pagar);
                    frameTelaPrincipal.Navigate(novoLancamentoPagar);
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    var novoLancamentoReceber = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Receber);
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

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var decisao = MessageBox.Show("Confirma exclusão do registro?",
                                          "Excluir",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (decisao == MessageBoxResult.Yes)
            {
                if (GridResultados.SelectedItem != null)
                {
                    switch (tipoCadastro)
                    {
                        case TipoCadastroEnum.Aluno:
                            repAluno.Excluir(GridResultados.SelectedItem as Aluno);
                            GridResultados.ItemsSource = repAluno.RetornaTodos().Take(100);
                            break;
                        case TipoCadastroEnum.Funcionario:
                            repFuncionario.Excluir(GridResultados.SelectedItem as Funcionario);
                            GridResultados.ItemsSource = repFuncionario.RetornaTodos().Take(100);
                            break;
                        case TipoCadastroEnum.Produto:
                            repProduto.Excluir(GridResultados.SelectedItem as Produto);
                            GridResultados.ItemsSource = repProduto.RetornaTodos().Take(100);
                            break;
                        case TipoCadastroEnum.Usuario:
                            var usuarioExcluir = GridResultados.SelectedItem as Usuario;
                            if (usuarioExcluir.Nome != "admin")
                                repUsuario.Excluir(usuarioExcluir);
                            else
                            {
                                MessageBox.Show("Não é possível excluir o usuário administrador",
                                                "Excluir",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Error);
                                return;
                            }
                            GridResultados.ItemsSource = repUsuario.RetornaTodos().Take(100);
                            break;
                        case TipoCadastroEnum.LancamentoPagar:
                            repLancamento.Excluir(GridResultados.SelectedItem as Lancamento);
                            GridResultados.ItemsSource = repLancamento.RetornaTodos().Take(100);
                            break;
                        case TipoCadastroEnum.LancamentoReceber:
                            repLancamento.Excluir(GridResultados.SelectedItem as Lancamento);
                            GridResultados.ItemsSource = repLancamento.RetornaTodos().Take(100);
                            break;
                        default:
                            break;
                    }
                    MessageBox.Show("Registro excluido com sucesso",
                                    "Excluir",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Selecione um registro para excluí-lo",
                                    "Excluir",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return;
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private List<String> GetListaPropriedades<T>()
        {
            List<String> retorno = new List<string>();
            Type type = typeof(T);

            foreach (PropertyInfo pInfo in type.GetProperties())
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)Attribute
                    .GetCustomAttribute(pInfo, typeof(DisplayNameAttribute));

                if (attr != null && !String.IsNullOrEmpty(attr.DisplayName))
                    retorno.Add(attr.DisplayName);
            }
            return retorno.OrderBy(e => e).ToList();
        }

        private void GridResultados_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Handle") || e.PropertyName.Equals("Senha"))
                e.Column.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
