﻿using System;
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

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for Contas.xaml
    /// </summary>
    public partial class Contas : Page
    {
        private Frame frameTelaPrincipal;
        public Contas(Frame frameTelaPrincipal)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }
    }
}
