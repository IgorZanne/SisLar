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
            //var sessionFactory = NHibernateHelper.SessionFactory;
            try
            {
                //var usuarios = repUsuario.RetornaTodos();
                //var consulta = usuarios.Where(u => u.Login.ToUpper().Equals(edtUsuario.Text.ToUpper()));
                //if (!consulta.Any())
                //    MessageBox.Show("Usuário não encontrado!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                //var usuario = consulta.FirstOrDefault();
                //if (!usuario.Senha.Equals(edtSenha.Password))
                //    MessageBox.Show("Senha incorreta!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);


                var usuarioAcesso =new Usuario() { Nome = "Administrador" };
                var telaPrincipal = new TelaPrincipal(usuarioAcesso);
                telaPrincipal.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                //sessionFactory.Dispose();
                //sessionFactory.Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
