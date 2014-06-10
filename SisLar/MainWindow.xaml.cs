using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using SisLar.Model;
using SisLar.Model.Repository;
using SisLar.Model.Entities;
using SisLar.View;
using System.Windows.Automation.Peers;

namespace SisLar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IRepositorio<Usuario> repUsuario;

        public MainWindow()
        {
            InitializeComponent();
            repUsuario = new Repositorio<Usuario>();
            edtUsuario.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var sessionFactory = NHibernateHelper.SessionFactory;
            try
            {
                var consulta = repUsuario.Consulta(u => u.Login.ToUpper().Equals(edtUsuario.Text.ToUpper()));
                if (!consulta.Any())
                {
                    MessageBox.Show("Usuário não encontrado!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.edtUsuario.Focus();
                    return;
                }

                var usuario = consulta.FirstOrDefault();
                if (!usuario.Senha.Equals(edtSenha.Password))
                {
                    MessageBox.Show("Senha incorreta!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.edtSenha.Focus();
                    return;
                }

                var usuarioAcesso =new Usuario() { Nome = usuario.Nome };
                var telaPrincipal = new TelaPrincipal(usuarioAcesso);
                telaPrincipal.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                sessionFactory.Dispose();
                sessionFactory.Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void edtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((TextBox)sender).MoveFocus(request);
            }
        }

        private void edtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((PasswordBox)sender).MoveFocus(request);
            }
        }
    }
}
