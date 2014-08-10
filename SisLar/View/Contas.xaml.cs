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
using SisLar.Model.Entities;
using SisLar.Model.Repository;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for Contas.xaml
    /// </summary>
    public partial class Contas : Page
    {
        private Frame frameTelaPrincipal;
        private TipoLancamentoEnum tipoLancamento;
        private Lancamento LancamentoAtual;
        private IRepositorio<Lancamento> repLancamento;
        private Index TelaIndex;

        public virtual List<String> TipoListString { get { return System.Enum.GetValues(typeof(TipoLancamentoEnum)).Cast<String>().ToList(); } }

        public Contas(Frame frameTelaPrincipal, TipoLancamentoEnum tipoLancamento, Lancamento lancamentoAtual)
        {
            this.tipoLancamento = tipoLancamento;
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.LancamentoAtual = lancamentoAtual;
            this.repLancamento = new Repositorio<Lancamento>();
            InitializeComponent();

            this.DataContext = this.LancamentoAtual;
            cbTipo.ItemsSource = Enum.GetValues(typeof(TipoLancamentoEnum)).Cast<TipoLancamentoEnum>();

            if (tipoLancamento == TipoLancamentoEnum.Pagar)
                this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.LancamentoPagar);
            else
                this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.LancamentoReceber);


            cbTipo.Text = tipoLancamento == TipoLancamentoEnum.Pagar ? "A Pagar" : "A Receber";
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verifica campos obrigatórios
            if (String.IsNullOrEmpty(cbTipo.Text))
            {
                MessageBox.Show("Informe um tipo", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(dataVencimento.Text))
            {
                MessageBox.Show("Informe a data de vencimento", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region Validações
            
            #endregion

            #region Post das alterações
            if (LancamentoAtual.Handle == 0)
            {
                repLancamento.Inclui(LancamentoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Lançamento inserido com sucesso!");
            }
            else
            {
                repLancamento.Altera(LancamentoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Lançamento alterado com sucesso!");
            }
            #endregion

            #region Retornar ao index
            frameTelaPrincipal.Navigate(this.TelaIndex);
            #endregion
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            edtValor.Focus();
        }
    }
}
