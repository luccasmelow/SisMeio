using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sismeio.Models;
using Sismeio.Base;


namespace Sismeio
{
    /// <summary>
    /// Lógica interna para RealizarVendas.xaml
    /// </summary>
    public partial class RealizarVendas : Window
    {
       
        public RealizarVendas()
        {
            InitializeComponent();
            Loaded += RealizarVendas_Loaded;
        }

        private void RealizarVendas_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var conexao = new Conexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            List <Produto> ListaVenda = new List<Produto>();



            ListaVenda.Add(new Produto()
            {
                Id= 256,
                Descricao="Chinelo Vizzano",
                Quantidade=5,
                ValorUnitario=250
                


            });
            ListaVenda.Add(new Produto()
            {
                Id = 215,
                Descricao = "Rasteira Vizzano",
                Quantidade = 2,
                ValorUnitario = 100



            });
            ListaVenda.Add(new Produto()
            {
                Id = 258,
                Descricao = "Chinelo Básico Havaianas",
                Quantidade = 1,
                ValorUnitario = 50



            });




            dataGridVenda.ItemsSource = ListaVenda;
        }
        private void mnuInicial_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void mnuRealizarVenda_Click(object sender, RoutedEventArgs e)
        {
            RealizarVendas vsRealizarVendas = new RealizarVendas();

            vsRealizarVendas.ShowDialog();
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

        private void btnConfirmaVenda_Click(object sender, RoutedEventArgs e)
        {

            Inserir_Teste();


            MessageBoxResult result = MessageBox.Show("Venda Realizada com sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnCancelaVenda_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Deseja Realmente cancelar a venda", "Confirmação",MessageBoxButton.OKCancel, MessageBoxImage.Information);

            this.Close();            
        }

        private void Inserir_Teste()
        {
            try
            {
                Vendas vendas = new Vendas();
                vendas.Valor = 120;
                vendas.Desconto = 0.1;
                vendas.Quantidade = 1;
                vendas.Codigo = 468514;
                vendas.Produtos = "PIX";
                vendas.Datavenda = 25/08/2021;
                vendas.Categoria = "PIX";
                vendas.Marca = "PIX";
                vendas.Valoruni = 120;
                vendas.FormaPagamento = "PIX";

                VendasDAO VendasDAO = new VendasDAO();
                VendasDAO.Insert(vendas);

                MessageBox.Show(" O funcionário foi adicionado com com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado! ( não inseriu nada em BD)", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           
        }
    }
}
