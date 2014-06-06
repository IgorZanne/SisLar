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
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NHibernateConf.Initialize("NHibernate");
            var USUARIO = repUsuario.Retorna(1);
            var usuarios = repUsuario.RetornaTodos();
            var consulta = usuarios.Where(u => u.Login.ToUpper().Equals(edtUsuario.Text.ToUpper()));
            if (!consulta.Any())
                MessageBox.Show("Usuário não encontrado", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Usuário encontrado", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        
    }
}
