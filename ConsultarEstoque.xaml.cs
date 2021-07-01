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

namespace Sismeio
{
    /// <summary>
    /// Lógica interna para ConsultarEstoque.xaml
    /// </summary>
    public partial class ConsultarEstoque : Window
    {
        public ConsultarEstoque()
        {
            InitializeComponent();
            Loaded += ConsultarEstoque_Loaded;
        }

        private void ConsultarEstoque_Loaded(object sender, RoutedEventArgs e)
        {
            List<Produto> ListaEstoque = new List<Produto>();


            ListaEstoque.Add(new Produto()
            {
                Id = 001,
                Descricao = "Chinelo Vermelho",
                Categoria = "Chinelo",
                Quantidade = 2,
                ValorUnitario = 49.90,
                ValorEstoque = 99.80,
                Marca = "Havaiana",
                Numeracao = 34


            });

            ListaEstoque.Add(new Produto()
            {
                Id = 009,
                Descricao = "Chinelo Verde",
                Categoria = "Chinelo",
                Quantidade = 2,
                ValorUnitario = 49.90,
                ValorEstoque = 99.80,
                Marca = "Havaiana",
                Numeracao = 34


            });

            ListaEstoque.Add(new Produto()
            {
                Id = 002,
                Descricao = "Sandália Dourada",
                Categoria = "Sandália",
                Quantidade = 3,
                ValorUnitario = 99.90,
                ValorEstoque = 299.70,
                Marca = "Ramarim",
                Numeracao = 37


            });

            ListaEstoque.Add(new Produto()
            {
                Id = 005,
                Descricao = "Sandália Rosa",
                Categoria = "Sandália",
                Quantidade = 1,
                ValorUnitario = 99.90,
                ValorEstoque = 99.90,
                Marca = "Ramarim",
                Numeracao = 39


            });
            ListaEstoque.Add(new Produto()
            {
                Id = 012,
                Descricao = "Sandália Rosa",
                Categoria = "Sandália",
                Quantidade = 1,
                ValorUnitario = 99.90,
                ValorEstoque = 99.90,
                Marca = "Ramarim",
                Numeracao = 35


            });

            ListaEstoque.Add(new Produto()
            {
                Id = 008,
                Descricao = "Tênia Preto",
                Categoria = "Tênis",
                Quantidade = 5,
                ValorUnitario = 300.00,
                ValorEstoque = 1.500,
                Marca = "Adidas",
                Numeracao = 39


            });



            dataGridEstoque.ItemsSource = ListaEstoque;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarProduto vsAtualizarProduto = new AtualizarProduto();

            vsAtualizarProduto.ShowDialog();
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


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
