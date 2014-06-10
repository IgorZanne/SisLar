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

        public CadastroUsuario(Frame frameTelaPrincipal)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.repUsuario = new Repositorio<Usuario>();
            InitializeComponent();
        }

        private void PreencherFormulario(Usuario usuario)
        {
            edtCodigo.Text = usuario.Codigo.ToString();
            edtLogin.Text = usuario.Login;
            edtNome.Text = usuario.Nome;
            edtSenha.Password = usuario.Senha;
        }

        private void CarregarDoFormulario()
        {
            //UsuarioEditando.Value = Convert.ToInt32(edtCodigo.Text);
            //edtLogin.Text = usuario.Login;
            //edtNome.Text = usuario.Nome;
            //edtSenha.Password = usuario.Senha;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verificar se usuário já existe
            var jaExiste = repUsuario
                .Consulta(u => u.Login.ToUpper().Equals(edtLogin.Text.ToUpper()))
                .Any();
            if (jaExiste)
            {
                MessageBox.Show("Já existe usuário com o mesmo login", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.edtLogin.Focus();
                return;
            }
            #endregion

            #region Verifica se a senha é válida
            if (edtSenha.Password.Length <= 4)
            {
                MessageBox.Show("A senha deve conter mais de 4 caracteres", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.edtSenha.Focus();
                return;
            }
            #endregion

            var novo = new Usuario()
            {
                Codigo = Convert.ToInt32(edtCodigo.Text),
                Login = edtLogin.Text,
                Nome = edtNome.Text,
                Senha = edtSenha.Password
            };
            repUsuario.Inclui(novo);
            MessageBox.Show("Usuário inserido com sucesso", "Erro", MessageBoxButton.OK, MessageBoxImage.Information);

            #region Retornar ao index
            var window = Window.GetWindow(this);
            var pageIndex = new Index(frameTelaPrincipal, TipoCadastroEnum.Usuario);
            frameTelaPrincipal.Navigate(pageIndex);
            #endregion
        }
    }
}
