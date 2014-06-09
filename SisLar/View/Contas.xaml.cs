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

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for Contas.xaml
    /// </summary>
    public partial class Contas : Page
    {
        private Frame frameTelaPrincipal;
        private TipoLancamentoEnum tipoLancamento;
        public Contas(Frame frameTelaPrincipal, TipoLancamentoEnum tipoLancamento)
        {
            this.tipoLancamento = tipoLancamento;
            this.frameTelaPrincipal = frameTelaPrincipal;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }
    }
}
