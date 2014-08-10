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
using System.Text.RegularExpressions;
using SisLar.Model.Enum;
using System.Windows.Forms;
using System.IO;

namespace SisLar.View
{
    /// <summary>
    /// Interaction logic for CadastroAluno.xaml
    /// </summary>
    public partial class CadastroAluno : Page
    {
        private Frame frameTelaPrincipal;
        private Aluno AlunoAtual;
        private IRepositorio<Aluno> repAluno;
        private Index TelaIndex;
        private const String sourceImagens = "ImagensSalvas";
        private String imagemApresentada = String.Empty;

        public CadastroAluno(Frame frameTelaPrincipal, Aluno AlunoAtual)
        {
            this.frameTelaPrincipal = frameTelaPrincipal;
            this.AlunoAtual = AlunoAtual;
            this.repAluno = new Repositorio<Aluno>();
            InitializeComponent();

            cbSexo.ItemsSource = Enum.GetValues(typeof(SexoEnum)).Cast<SexoEnum>();
            cbPeriodo.ItemsSource = Enum.GetValues(typeof(PeriodoEnum)).Cast<PeriodoEnum>();

            this.DataContext = AlunoAtual;
            this.TelaIndex = new Index(this.frameTelaPrincipal, TipoCadastroEnum.Aluno);

            if (!String.IsNullOrEmpty(AlunoAtual.CaminhoFoto))
            {
                imagemApresentada = System.IO.Path.GetFullPath(sourceImagens + "\\" + AlunoAtual.CaminhoFoto);
                imgFoto.Source = CarregarImagem(imagemApresentada);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frameTelaPrincipal.NavigationService.GoBack();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            #region Verifica campos obrigatórios
            if (String.IsNullOrEmpty(edtMatricula.Text))
            {
                System.Windows.MessageBox.Show("Informe um número de matrícula", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(edtNome.Text))
            {
                System.Windows.MessageBox.Show("Informe o nome do aluno", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(dataNascimento.Text))
            {
                System.Windows.MessageBox.Show("Informe a data de nascimento", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(dataMatricula.Text))
            {
                System.Windows.MessageBox.Show("Informe a data de matrícula", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region Validações
            Int64 numeroMatricula;
            if (!Int64.TryParse(edtMatricula.Text, out numeroMatricula))
            {
                System.Windows.MessageBox.Show("O número da matrícula é inválido", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var matricula = Regex.Match(edtMatricula.Text, @"\d+");
            var matriculaJaExiste = repAluno
                .Consulta(a => a.Matricula == numeroMatricula
                            && a.Handle != AlunoAtual.Handle)
                .Any();
            if (matriculaJaExiste)
            {
                System.Windows.MessageBox.Show("Já existe outro aluno cadastrado com esta matrícula", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            #region Post das alterações

            if (!Directory.Exists(sourceImagens))
                Directory.CreateDirectory(sourceImagens);

            var nomeImagem = AlunoAtual.CaminhoFoto;
            var arquivo = sourceImagens + "\\" + nomeImagem;
            if (File.Exists(arquivo))
            {
                nomeImagem = "1-" + AlunoAtual.CaminhoFoto;
                arquivo = sourceImagens + "\\" + nomeImagem;
            }

            File.Copy(imagemApresentada, arquivo, true);

            if (AlunoAtual.Handle == 0)
            {
                repAluno.Inclui(AlunoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Aluno inserido com sucesso!");
            }
            else
            {
                repAluno.Altera(AlunoAtual);
                this.TelaIndex.AlteraTextoStatusBar("Aluno alterado com sucesso!");
            }
            #endregion

            #region Retornar ao index
            frameTelaPrincipal.Navigate(TelaIndex);
            #endregion
        }

        private void edtMatricula_Loaded(object sender, RoutedEventArgs e)
        {
            edtMatricula.Focus();
        }

        private String CalculaIdade(DateTime data)
        {
            DateTime hoje = DateTime.Today;

            int days = hoje.Day - data.Day;
            if (days < 0)
            {
                hoje = hoje.AddMonths(-1);
                days += DateTime.DaysInMonth(hoje.Year, hoje.Month);
            }

            int months = hoje.Month - data.Month;
            if (months < 0)
            {
                hoje = hoje.AddYears(-1);
                months += 12;
            }

            int years = hoje.Year - data.Year;

            return String.Format("{0} Ano(s), {1} Mes(es), {2} dia(s)", years, months, days);
        }

        private void dataNascimento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataNascimento.SelectedDate.HasValue)
                edtIdade.Text = CalculaIdade(dataNascimento.SelectedDate.Value);
            else
                edtIdade.Text = String.Empty;
        }

        private void btnSelecionarImagem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.tiff, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.tiff;*.bmp";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AlunoAtual.CaminhoFoto = dlg.SafeFileName;
                imgFoto.Source = CarregarImagem(dlg.FileName);
                imgFoto.ToolTip = dlg.FileName;
                imagemApresentada = dlg.FileName;
            }
        }

        private BitmapImage CarregarImagem(String caminho)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(caminho);
            bitmap.EndInit();
            return bitmap;
        }

        private void btnAnexar_Click(object sender, RoutedEventArgs e)
        {
            var novoDovumento = new CadastroAnexo(frameTelaPrincipal, AlunoAtual.Handle);
            frameTelaPrincipal.Navigate(novoDovumento);
        }
    }
}
