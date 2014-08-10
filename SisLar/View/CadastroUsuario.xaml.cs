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
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Page
    {
        private Frame frameTelaPrincipal;
        private IRepositorio<Usuario> repUsuario;
        private Usuario UsuarioAtual;
        private Index TelaIndex;

        public CadastroUsuario(Frame frameTelaPrincipal, Usuario UsuarioEditar)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.repUsuario = new Repositorio<Usuario>();
            this.UsuarioAtual = UsuarioEditar;
            InitializeComponent();

            this.DataContext = this.UsuarioAtual;
            this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.Usuario);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verificar se usuário já existe
            if (UsuarioAtual.Handle > 0)
            {
                var jaExiste = repUsuario
                    .Consulta(u => u.Handle != UsuarioAtual.Handle
                                && u.Login.ToUpper().Equals(edtLogin.Text.ToUpper()))
                    .Any();
                if (jaExiste)
                {
                    MessageBox.Show("Já existe usuário com o mesmo login", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.edtLogin.Focus();
                    return;
                }
            }
            #endregion

            #region Verifica se a senha é válida
            if (edtSenha.Password.Length <= 4)
            {
                MessageBox.Show("A senha deve conter mais de 4 caracteres", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.edtSenha.Focus();
                return;
            }
            else
            {
                this.UsuarioAtual.Senha = edtSenha.Password;
            }
            #endregion

            if (UsuarioAtual.Handle == 0)
            {
                repUsuario.Inclui(UsuarioAtual);
                this.TelaIndex.AlteraTextoStatusBar("Usuário inserido com sucesso!");
            }
            else
            {
                repUsuario.Altera(UsuarioAtual);
                this.TelaIndex.AlteraTextoStatusBar("Usuário alterado com sucesso!");
            }

            #region Retornar ao index
            frameTelaPrincipal.Navigate(this.TelaIndex);
            #endregion
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            edtNome.Focus();
        }
    }
}
