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
using SisLar.Model.Repository;
using SisLar.Model.Entities;
using SisLar.Model;
using System.Windows.Forms;
using System.IO;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for CadastroAnexo.xaml
    /// </summary>
    public partial class CadastroAnexo : Page
    {
        private Frame frameTelaPrincipal;
        private IRepositorio<Anexo> repAnexo;
        private IRepositorio<Aluno> repAluno;
        private Anexo AnexoAtual;
        private Aluno AlunoAtual;
        private const string pastaDocumentos = "DocumentosAnexos";

        public CadastroAnexo(Frame frameTelaPrincipal, long handleAluno)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.repAnexo = new Repositorio<Anexo>();
            this.repAluno = new Repositorio<Aluno>();
            this.AlunoAtual = repAluno.Retorna(handleAluno);

            InitializeComponent();

            this.AnexoAtual = new Anexo()
            {
                DataImportacao = DateTime.Now,
                Aluno = handleAluno
            };
            this.DataContext = this.AnexoAtual;
            var documentosAluno = repAnexo.Consulta(e => e.Aluno == handleAluno);
            if (documentosAluno.Any())
            {
                gridDocumentos.ItemsSource = documentosAluno;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verifica campos obrigatórios
            if (String.IsNullOrEmpty(edtDescricao.Text))
            {
                System.Windows.MessageBox.Show("Informe uma descrição", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(edtArquivo.Text))
            {
                System.Windows.MessageBox.Show("Informa um arquivo", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            if (!Directory.Exists(pastaDocumentos))
                Directory.CreateDirectory(pastaDocumentos);

            var pastaAluno = pastaDocumentos + "\\" + AlunoAtual.Handle;
            if (!Directory.Exists(pastaAluno))
                Directory.CreateDirectory(pastaAluno);

            var nomeArquivo = AnexoAtual.Arquivo;
            var arquivo = pastaAluno + "\\" + nomeArquivo;
            if (!File.Exists(arquivo))
            {
                File.Copy(edtArquivo.Text, arquivo, true);
            }

            if (AnexoAtual.Handle == 0)
            {
                repAnexo.Inclui(AnexoAtual);
                this.AlteraTextoStatusBar("Documento inserido com sucesso!");
            }
            else
            {
                repAnexo.Altera(AnexoAtual);
                this.AlteraTextoStatusBar("Documento alterado com sucesso!");
            }

            var documentosAluno = repAnexo.Consulta(a => a.Aluno == AnexoAtual.Aluno);
            gridDocumentos.ItemsSource = documentosAluno;
        }

        private void AlteraTextoStatusBar(string p)
        {
            edtStatusBar.Text = p;
        }

        private void gridDocumentos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Handle") || e.PropertyName.Equals("Aluno"))
                e.Column.Visibility = System.Windows.Visibility.Hidden;

            if (e.PropertyType == typeof(Nullable<DateTime>) || e.PropertyType == typeof(DateTime))
            {
                DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
                if (dataGridTextColumn != null)
                {
                    dataGridTextColumn.Binding.StringFormat = "{0:dd/MM/yyyy}";
                }
            }

            string displayName = EntidadeHelper.GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
                e.Column.Header = displayName;
        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.tiff, *.bmp, *.doc, *.docx, *.xls)|*.jpg;*.jpeg;*.png;*.gif;*.tiff;*.bmp;*.doc;*.docx;*.xls";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AnexoAtual.Arquivo = dlg.SafeFileName;
                edtArquivo.Text = dlg.FileName;
            }
        }

        private void gridDocumentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridDocumentos.SelectedItem != null)
            {
                this.AnexoAtual = gridDocumentos.SelectedItem as Anexo;
                this.DataContext = this.AnexoAtual;
            }
            else
            {
                System.Windows.MessageBox.Show("Selecione um registro para edita-lo",
                                    "Editar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                return;
            }
        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            var aquivo = pastaDocumentos + "\\" + AnexoAtual.Aluno + "\\" + AnexoAtual.Arquivo;
            if (File.Exists(aquivo))
                System.Diagnostics.Process.Start(aquivo);
            else
                System.Windows.MessageBox.Show("Arquivo não encontrado!", "Erro", MessageBoxButton.OK);
        }
    }
}
