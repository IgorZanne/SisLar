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

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for CadastroFuncionario.xaml
    /// </summary>
    public partial class CadastroFuncionario : Page
    {
        private Frame frameTelaPrincipal;
        private Funcionario FuncionarioAtual;
        private IRepositorio<Funcionario> repFuncionario;
        private Index TelaIndex;
        private SisLar.ViewModel.CadastroFuncionarioViewModel teste;

        public CadastroFuncionario(Frame frameTelaPrincipal, Funcionario funcionarioAtual)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.FuncionarioAtual = funcionarioAtual;
            this.repFuncionario = new Repositorio<Funcionario>();
            InitializeComponent();
            
            cbSexo.ItemsSource = Enum.GetValues(typeof(SexoEnum)).Cast<SexoEnum>();
            this.DataContext = this.FuncionarioAtual;
            this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.Funcionario);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verifica campos obrigatórios
            if (String.IsNullOrEmpty(edtNome.Text))
            {
                MessageBox.Show("Informe o nome", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(edtSetor.Text))
            {
                MessageBox.Show("Informe o setor", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region Validações
            
            #endregion

            #region Post das alterações
            if (FuncionarioAtual.Handle == 0)
            {
                repFuncionario.Inclui(FuncionarioAtual);
                this.TelaIndex.AlteraTextoStatusBar("Funcionário inserido com sucesso!");
            }
            else
            {
                repFuncionario.Altera(FuncionarioAtual);
                this.TelaIndex.AlteraTextoStatusBar("Funcionário alterado com sucesso!");
            }
            #endregion

            #region Retornar ao index
            frameTelaPrincipal.Navigate(this.TelaIndex);
            #endregion
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            edtCodigo.Focus();
        }
    }
}
