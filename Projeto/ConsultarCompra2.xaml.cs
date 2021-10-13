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
    /// Lógica interna para ConsultarCompra2.xaml
    /// </summary>
    public partial class ConsultarCompra2 : Window
    {
        public ConsultarCompra2()
        {
            InitializeComponent();
            Loaded += ConsultarCompras2_Loaded;
        }

        private void ConsultarCompras2_Loaded(object sender, RoutedEventArgs e)
        {
            List<Compras2> listacompra2 = new List<Compras2>();


            listacompra2.Add(new Compras2()
            {
                Codigo = 001,
                Nome = "Chinelo Vermelho",
                Categoria = "Feminino",
                Quantidade = 2,
                ValorUnitario = 49.90,
                ValorTotal = 99.80,
                Marca = "Havaiana",
                Numeracao = 34


            });

            dataGridCompras2.ItemsSource = listacompra2;
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

        private void btnfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
 }



