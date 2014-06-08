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
using System.Windows.Shapes;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        //public IRepositorio<Usuario> repUsuario;

        public TelaPrincipal()
        {
            InitializeComponent();
            //repAlunos = new Repositorio<Usuario>();
            
        }

        private void alunoCadastro_Click(object sender, RoutedEventArgs e)
        {
            //this.GridAlunos.Items = 
        }

        private void funcionariosCadastro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void estoqueProdutos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contasPagar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contasReceber_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
