using System;
using System.Windows;
using System.Windows.Controls;
using Sismeio.Models;

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
        public CadastroCliente( int id)
        {
            _id = id; 
            InitializeComponent();
            Loaded += CadastroCliente_Loaded;
        }

        private void CadastroCliente_Loaded (object sender, RoutedEventArgs e)
        {
            _cliente = new Cliente();
            try
            {
                var dao = new ClienteDAO();
                _cliente = dao.GetById(_id);

                Codigo.Text = _cliente.Codigo.ToString();
                Nome.Text = _cliente.Nome;
                RG.Text = _cliente.RG;
                CPF.Text = _cliente.CPF;
                Telefone.Text = _cliente.Telefone;
                _cliente.DataNascimento = DateTime.Now;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
        private void bttfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btcadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nome = Nome.Text;
                cliente.CPF = CPF.Text;
                cliente.RG = RG.Text;
                cliente.DataNascimento = DateTime.Now;
                cliente.Telefone = Telefone.Text;


                ClienteDAO clientedao = new ClienteDAO();
                clientedao.Insert(cliente);

            }
            catch (Exception ex)
            {
               
            }
        }

        private void bttfechar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
