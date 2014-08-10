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
using SisLar.Model;

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
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Aluno>();
                    this.repAluno = new Repositorio<Aluno>();
                    AlteraTextoStatusBar("Lista de alunos cadastrados no sistema.");
                    break;
                case TipoCadastroEnum.Funcionario:
                    gbContainer.Header = "Funcionários";
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Funcionario>();
                    this.repFuncionario = new Repositorio<Funcionario>();
                    AlteraTextoStatusBar("Lista de funcionários cadastrados no sistema.");
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    gbContainer.Header = "Contas a pagar";
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Lancamento>();
                    this.repLancamento = new Repositorio<Lancamento>();
                    AlteraTextoStatusBar("Lista de contas a pagar cadastradas no sistema.");
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    gbContainer.Header = "Contas a receber";
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Lancamento>();
                    this.repLancamento = new Repositorio<Lancamento>();
                    AlteraTextoStatusBar("Lista de contas a receber cadastradsas no sistema.");
                    break;
                case TipoCadastroEnum.Produto:
                    gbContainer.Header = "Produtos";
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Produto>();
                    this.repProduto = new Repositorio<Produto>();
                    AlteraTextoStatusBar("Lista de produtos cadastrados no sistema.");
                    break;
                case TipoCadastroEnum.Usuario:
                    gbContainer.Header = "Usuários";
                    cbFiltro.ItemsSource = EntidadeHelper.GetListaPropriedades<Usuario>();
                    this.repUsuario = new Repositorio<Usuario>();
                    AlteraTextoStatusBar("Lista de usuários cadastrados no sistema.");
                    break;
            }

            AtualizarGrid();
            
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            switch (this.tipoCadastro)
            {
                case TipoCadastroEnum.Aluno:
                    var novoAluno = new CadastroAluno(frameTelaPrincipal, new Aluno());
                    frameTelaPrincipal.Navigate(novoAluno);
                    break;
                case TipoCadastroEnum.Funcionario:
                    var novoFuncionario = new CadastroFuncionario(frameTelaPrincipal, new Funcionario());
                    frameTelaPrincipal.Navigate(novoFuncionario);
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    Lancamento lancamentoPagar = new Lancamento() { DataInclusao = DateTime.Now, Tipo = TipoLancamentoEnum.Pagar };
                    var novoLancamentoPagar = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Pagar, lancamentoPagar);
                    frameTelaPrincipal.Navigate(novoLancamentoPagar);
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    Lancamento lancamentoReceber = new Lancamento() { DataInclusao = DateTime.Now, Tipo = TipoLancamentoEnum.Receber };
                    var novoLancamentoReceber = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Receber, lancamentoReceber);
                    frameTelaPrincipal.Navigate(novoLancamentoReceber);
                    break;
                case TipoCadastroEnum.Produto:
                    var novoProduto = new CadastroProduto(frameTelaPrincipal, new Produto());
                    frameTelaPrincipal.Navigate(novoProduto);
                    break;
                case TipoCadastroEnum.Usuario:
                    var novoUsuario = new CadastroUsuario(frameTelaPrincipal, new Usuario());
                    frameTelaPrincipal.Navigate(novoUsuario);
                    break;
                default:

                    break;
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (GridResultados.SelectedItem != null)
            {
                var decisao = MessageBox.Show("Confirma exclusão do registro?",
                                              "Excluir",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);
                if (decisao == MessageBoxResult.Yes)
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
                            if (usuarioExcluir.Handle != 1)
                            {
                                repUsuario.Excluir(usuarioExcluir);
                            }
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditarRegistro(true);
        }

        private void EditarRegistro(bool msgRegistroNaoSelecionado)
        {
            if (GridResultados.SelectedItem != null)
            {
                switch (this.tipoCadastro)
                {
                    case TipoCadastroEnum.Aluno:
                        var novoAluno = new CadastroAluno(frameTelaPrincipal, GridResultados.SelectedItem as Aluno);
                        frameTelaPrincipal.Navigate(novoAluno);
                        break;
                    case TipoCadastroEnum.Funcionario:
                        var novoFuncionario = new CadastroFuncionario(frameTelaPrincipal, GridResultados.SelectedItem as Funcionario);
                        frameTelaPrincipal.Navigate(novoFuncionario);
                        break;
                    case TipoCadastroEnum.LancamentoPagar:
                        var novoLancamentoPagar = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Pagar, GridResultados.SelectedItem as Lancamento);
                        frameTelaPrincipal.Navigate(novoLancamentoPagar);
                        break;
                    case TipoCadastroEnum.LancamentoReceber:
                        var novoLancamentoReceber = new Contas(frameTelaPrincipal, TipoLancamentoEnum.Receber, GridResultados.SelectedItem as Lancamento);
                        frameTelaPrincipal.Navigate(novoLancamentoReceber);
                        break;
                    case TipoCadastroEnum.Produto:
                        var novoProduto = new CadastroProduto(frameTelaPrincipal, GridResultados.SelectedItem as Produto);
                        frameTelaPrincipal.Navigate(novoProduto);
                        break;
                    case TipoCadastroEnum.Usuario:
                        var novoUsuario = new CadastroUsuario(frameTelaPrincipal, GridResultados.SelectedItem as Usuario);
                        frameTelaPrincipal.Navigate(novoUsuario);
                        break;
                    default:

                        break;
                }
            }
            else
            {
                if (msgRegistroNaoSelecionado)
                    MessageBox.Show("Selecione um registro para edita-lo",
                                        "Editar",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                return;
            }
        }

        private void GridResultados_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Handle") || e.PropertyName.Equals("Senha"))
                e.Column.Visibility = System.Windows.Visibility.Hidden;

            if (e.PropertyType == typeof(Nullable<DateTime>) || e.PropertyType == typeof(DateTime))
            {
                DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
                if (dataGridTextColumn != null)
                {
                    dataGridTextColumn.Binding.StringFormat = "{0:dd/MM/yyyy}";
                }
            }

            if (e.PropertyType == typeof(Nullable<bool>) || e.PropertyType == typeof(bool))
            {
                DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
                if (dataGridTextColumn != null)
                {
                    //;
                }
            }

            string displayName = EntidadeHelper.GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
                e.Column.Header = displayName;
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cbFiltro.Text))
            {
                MessageBox.Show("Informe um filtro", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var sessionFactory = NHibernateHelper.SessionFactory;
            using (var session = sessionFactory.OpenSession())
            {
                var sqlHelper = new SqlHelper();
                PropertyInfo coluna = null;
                switch (this.tipoCadastro)
                {
                    case TipoCadastroEnum.Aluno:
                        coluna = EntidadeHelper.GetNomePropriedade<Aluno>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Aluno>(repAluno.RetornaTodos(), coluna.Name, edtFiltro.Text);
                        break;
                    case TipoCadastroEnum.Funcionario:
                        coluna = EntidadeHelper.GetNomePropriedade<Funcionario>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Funcionario>(repFuncionario.RetornaTodos(), coluna.Name, edtFiltro.Text);
                        break;
                    case TipoCadastroEnum.LancamentoPagar:
                        coluna = EntidadeHelper.GetNomePropriedade<Lancamento>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Lancamento>(repLancamento.Consulta(cons => cons.Tipo == TipoLancamentoEnum.Pagar), coluna.Name, edtFiltro.Text);
                        break;
                    case TipoCadastroEnum.LancamentoReceber:
                        coluna = EntidadeHelper.GetNomePropriedade<Lancamento>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Lancamento>(repLancamento.Consulta(cons => cons.Tipo == TipoLancamentoEnum.Receber), coluna.Name, edtFiltro.Text);
                        break;
                    case TipoCadastroEnum.Produto:
                        coluna = EntidadeHelper.GetNomePropriedade<Produto>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Produto>(repProduto.RetornaTodos(), coluna.Name, edtFiltro.Text);
                        break;
                    case TipoCadastroEnum.Usuario:
                        coluna = EntidadeHelper.GetNomePropriedade<Usuario>(cbFiltro.Text);
                        GridResultados.ItemsSource = QueryableExtensions
                            .Search<Usuario>(repUsuario.RetornaTodos(), coluna.Name, edtFiltro.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        private void edtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((TextBox)sender).MoveFocus(request);
            }
        }

        internal protected void AlteraTextoStatusBar(String texto)
        {
            edtStatusBar.Text = texto;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            switch (tipoCadastro)
            {
                case TipoCadastroEnum.Aluno:
                    GridResultados.ItemsSource = repAluno.RetornaTodos();
                    break;
                case TipoCadastroEnum.Funcionario:
                    GridResultados.ItemsSource = repFuncionario.RetornaTodos();
                    break;
                case TipoCadastroEnum.LancamentoPagar:
                    GridResultados.ItemsSource = repLancamento.Consulta(e => e.Tipo == TipoLancamentoEnum.Pagar);
                    break;
                case TipoCadastroEnum.LancamentoReceber:
                    GridResultados.ItemsSource = repLancamento.Consulta(e => e.Tipo == TipoLancamentoEnum.Receber);
                    break;
                case TipoCadastroEnum.Produto:
                    GridResultados.ItemsSource = repProduto.RetornaTodos();
                    break;
                case TipoCadastroEnum.Usuario:
                    GridResultados.ItemsSource = repUsuario.RetornaTodos();
                    break;
            }
        }

        private void GridResultados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditarRegistro(false);
        }
    }
}
