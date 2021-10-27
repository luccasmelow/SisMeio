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

            LoadDataGrid();
           
            /*
            dataGridCaixa.ItemsSource = ListaGastos;
            */
        }
        private void LoadDataGrid()
        {


            try
            {
                var dao = new CaixaDAO();

                dataGridCaixa.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);

            }


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

        private void btnRelatorio_Click_1(object sender, RoutedEventArgs e)
        {
            RelatorioGastos vsRelatorioGastos = new RelatorioGastos();

            vsRelatorioGastos.ShowDialog();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastroCaixa vsCadastroCaixa = new CadastroCaixa();

            vsCadastroCaixa.ShowDialog();

            //isso confere

            LoadDataGrid();
        }

        private void Button_Vizualizar_Click(object sender, RoutedEventArgs e)
        {

            //ver oq ta errado 
            var caixaSelected = dataGridCaixa.SelectedItem as Caixa;

            //var window = new CadastroCaixa(caixaSelected.Codigo);

            //window.ShowDialog();

            LoadDataGrid();

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

            //LoadDataGrid();
            var caixaSelected = dataGridCaixa.SelectedItem as Caixa;

            var result = MessageBox.Show($"Deseja realmente remover o gasto {caixaSelected.Mes} ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new CaixaDAO();
                    dao.Delet(caixaSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
