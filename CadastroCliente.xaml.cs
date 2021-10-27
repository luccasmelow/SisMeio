using System;
using System.Windows;
using System.Windows.Controls;
using Sismeio.Models;
using Sismeio.Base;
using Sismeio.Helprs;

namespace Sismeio
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        private int _id;
        private Cliente _cliente;

        public CadastroCliente()
        {
            InitializeComponent();
            Loaded += CadastroCliente_Loaded;
        }
        public CadastroCliente(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastroCliente_Loaded;
        }

        private void CadastroCliente_Loaded(object sender, RoutedEventArgs e)
        {
            _cliente = new Cliente();


            LoadComboBox();

            if (_id > 0)
                Form();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AtualizarProduto atualizar = new AtualizarProduto();
            atualizar.Show();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void mnuInicial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuRealizarVenda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            CadastroProduto vsCadastrarProduto = new CadastroProduto();

            vsCadastrarProduto.ShowDialog();
        }


        private void mnuCadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente vsCadastrarCliente = new CadastroCliente();

            vsCadastrarCliente.ShowDialog();
        }

        private void mnuCadastrarCompra_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mnuConsultarEstoque_Click(object sender, RoutedEventArgs e)
        {
            ConsultarEstoque vsConsultarEstoque = new ConsultarEstoque();

            vsConsultarEstoque.ShowDialog();
        }

        private void mnuConsultarFuncionario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuConsultarCliente_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente vsConsultaCliente = new ConsultaCliente();

            vsConsultaCliente.ShowDialog();
        }

        private void mnuConsultarVenda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuControlarGastos_Click(object sender, RoutedEventArgs e)
        {
            ControlarGastos vsControlarGastos = new ControlarGastos();

            vsControlarGastos.ShowDialog();
        }

        private void mnuCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario vsCadastrarFuncionario = new CadastrarFuncionario();

            vsCadastrarFuncionario.ShowDialog();

        }

        private void btnRelatorio_Click_1(object sender, RoutedEventArgs e)
        {
            RelatorioGastos vsRelatorioGastos = new RelatorioGastos();

            vsRelatorioGastos.ShowDialog();
        }
        private void btcadastrar_Click(object sender, RoutedEventArgs e)
        {

            if (dtPickerDataNascimento.SelectedDate != null)
                _cliente.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;

            _cliente.Nome = Nome.Text;
            _cliente.CPF = CPF.Text;
            _cliente.RG = RG.Text;
            _cliente.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;
            _cliente.Telefone = Telefone.Text;

            _cliente.Endereco = new Endereco();
            _cliente.Endereco.Logradouro = Logradouro.Text;
            _cliente.Endereco.Bairro = Bairro.Text;
            _cliente.Endereco.Cidade = cidade.Text;

            if (int.TryParse(Numero.Text, out int numero))
                _cliente.Endereco.Numero = numero;

            if (comboBoxEstado.SelectedItem != null)
                _cliente.Endereco.Estado = comboBoxEstado.SelectedItem as string;

            SalvarInfo();
            
        }

        private bool Validate()
        {
            var validar = new ValidacaoCliente();
            var result = validar.Validate(_cliente);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }
                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            return result.IsValid;
        }
        private void SalvarInfo()
        {
            try
            {
                if (Validate())
                {

                    var dao = new ClienteDAO();

                    if (_cliente.Codigo == 0)
                    {
                        dao.Insert(_cliente);
                    }
                    else
                    {
                        dao.Update(_cliente);

                        MessageBox.Show("Cadastro realizado com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível realizar o cadastro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Form()
        {
            try
            {
                var dao = new ClienteDAO();
                _cliente = dao.GetById(_id);

                Codigo.Text = _cliente.Codigo.ToString();
                Nome.Text = _cliente.Nome;
                RG.Text = _cliente.RG;
                CPF.Text = _cliente.CPF;
                Telefone.Text = _cliente.Telefone;
                dtPickerDataNascimento.SelectedDate = _cliente.DataNascimento;


                if (_cliente.Endereco != null)
                {
                    Logradouro.Text = _cliente.Endereco.Logradouro;
                    Numero.Text = _cliente.Endereco.Numero.ToString();
                    Bairro.Text = _cliente.Endereco.Bairro;
                    cidade.Text = _cliente.Endereco.Cidade;
                   

                    comboBoxEstado.SelectedValue = _cliente.Endereco.Estado;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadComboBox()
        {
            try
            {
                comboBoxEstado.ItemsSource = Estado.List();
            }
            catch (Exception ex)
            {

            }
        }
        private void ClearInputs()
        {
           Nome.Text = "";
           CPF.Text = "";
           RG.Text = "";
           dtPickerDataNascimento.SelectedDate = null;
           Telefone.Text = "";

        }

        private void bttfechar_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja fechar esta janela?", "Sucesso", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)

                this.Close();

            else
                ClearInputs();
                
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Codigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBoxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
