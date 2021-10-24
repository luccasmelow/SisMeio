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

namespace Sismeio
{
    /// <summary>
    /// Lógica interna para ConsultarVendas.xaml
    /// </summary>
    public partial class ConsultarVendas : Window
    {
        public ConsultarVendas()
        {
            InitializeComponent();
            Loaded += ConsultarVendas_Loaded;
        }
        private void ConsultarVendas_Loaded(object sender, RoutedEventArgs e)
        {
            List<Vendas> listavendas = new List<Vendas>();



            listavendas.Add(new Vendas()
            {
                Codigo = 001,
                Produtos = "Chinelo Vermelho",
                Valor = 49.90,
                Datavenda = 23 / 10 / 2020


            });

            listavendas.Add(new Vendas()
            {
                Codigo = 009,
                Produtos = "Chinelo Verde",
                Valor = 49.90,
                Datavenda = 23 / 10 / 2020

            });

            listavendas.Add(new Vendas()
            {
                Codigo = 002,
                Produtos = "Sandália Dourada",
                Valor = 99.90,
                Datavenda = 23 / 10 / 2020


            }); dataGridVendas.ItemsSource = listavendas;
        }

            private void btnfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
