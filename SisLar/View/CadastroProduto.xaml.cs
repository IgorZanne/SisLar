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
using SisLar.Model.Entities;
using SisLar.Model.Repository;
using SisLar.Model.Enum;
using System.Text.RegularExpressions;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for CadastroProduto.xaml
    /// </summary>
    public partial class CadastroProduto : Page
    {
        private Frame frameTelaPrincipal;
        private Produto ProdutoAtual;
        private IRepositorio<Produto> repProduto;
        private Index TelaIndex;

        public CadastroProduto(Frame frameTelaPrincipal, Produto produtoAtual)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.ProdutoAtual = produtoAtual;
            this.repProduto = new Repositorio<Produto>();

            InitializeComponent();
            this.DataContext = this.ProdutoAtual;
            this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.Produto);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verifica campos obrigatórios
            if (String.IsNullOrEmpty(edtDescricao.Text))
            {
                MessageBox.Show("Informe uma descrição", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(edtUnidade.Text))
            {
                MessageBox.Show("Informe a unidade", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Double quantidade;
            if (String.IsNullOrEmpty(edtQuantidade.Text) || !Double.TryParse(edtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Informe uma quantidade válida", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region Validações
            
            #endregion

            #region Post das alterações
            if (ProdutoAtual.Handle == 0)
            {
                repProduto.Inclui(ProdutoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Produto inserido com sucesso!");
            }
            else
            {
                repProduto.Altera(ProdutoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Produto alterado com sucesso!");
            }
            #endregion

            #region Retornar ao index
            frameTelaPrincipal.Navigate(this.TelaIndex);
            #endregion
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            edtTipo.Focus();
        }

        public static bool onlyNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that allows numeric input only
            return !regex.IsMatch(text); // 
        }

        private void edtQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !onlyNumeric(e.Text);
        }
    }
}
