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
    /// Lógica interna para RelatorioGastos.xaml
    /// </summary>
    public partial class RelatorioGastos : Window
    {

        public RelatorioGastos()
        {
            InitializeComponent();
            Loaded += RelatorioGastos_Loaded;
        }

        private void RelatorioGastos_Loaded(object sender, RoutedEventArgs e)
        {
            List<Despesa> ListaGastos = new List<Despesa>();


            ListaGastos.Add(new Despesa()
            {
                abertas ="Conta de Energia",
                vencidas="Pagamento - Vendedora",
                pagas="Pagamento - Caixa",
                caixa=2000,
                debito=3000



            });
            ListaGastos.Add(new Despesa()
            {
                abertas = "Água",
                pagas = "Pedido Ramarim"


            });
            ListaGastos.Add(new Despesa()
            {
                abertas = "Pedido Arezzo",
                pagas = "Pedido Adidas",
                caixa=0
               
            });

            dataGridEstoque.ItemsSource = ListaGastos;
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

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
