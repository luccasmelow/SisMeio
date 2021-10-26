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
    /// Lógica interna para ControlarGastos.xaml
    /// </summary>
    public partial class ControlarGastos : Window
    {

        public ControlarGastos()
        {
            InitializeComponent();
            Loaded += ControlarGastos_Loaded;
        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ControlarGastos_Loaded(object sender, RoutedEventArgs e)
        {

            LoadDataGrid();

            //Erro
            /*
            try
            {
                var dao = new GastosDAO();

                foreach (Gasto gas in dao.List())
                {
                    MessageBox.Show("R$" + gas.Valor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            */





            //List<Despesa> ListaGastos = new List<Despesa>();


            //ListaGastos.Add(new Despesa()
            //{
            //  id= 0158,
            // descricao = "Conta de Energia",
            //valordesp = 500.97


            // });
            // ListaGastos.Add(new Despesa()
            // {
            //   id = 0159,
            // descricao = "Água",
            //  valordesp = 150.77


            // });
            // ListaGastos.Add(new Despesa()
            // {
            //  id = 0160,
            // descricao = "Pedido Arezzo",
            // valordesp = 2000.99


            // });




            //dataGridGastos.ItemsSource = ListaGastos;
        }

        private void LoadDataGrid()
        {

            //erro
            
            try
            {
                var dao = new GastosDAO();

                dataGridGastos.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error );

            }
            

        }
        
        private void mnuInicial_Click(object sender, RoutedEventArgs e)
        {
            TelaInicial vstelaInicial = new TelaInicial();

            vstelaInicial.ShowDialog();
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
            ConsultarFuncionario vsConsultarFuncionario = new ConsultarFuncionario();

            vsConsultarFuncionario.ShowDialog();
        }

        private void mnuConsultarCliente_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente vsConsultaCliente = new ConsultaCliente();


            vsConsultaCliente.ShowDialog();
            
        }

        private void mnuConsultarVenda_Click(object sender, RoutedEventArgs e)
        {
            ConsultarVendas vsConsultarVendas = new ConsultarVendas();

            vsConsultarVendas.ShowDialog();
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

        private void btnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            CadastroGasto vsCadastroGasto = new CadastroGasto();

            vsCadastroGasto.ShowDialog();

            //isso confere

            LoadDataGrid();
        }


        private void Button_Vizualizar_Click(object sender, RoutedEventArgs e)
        {
            //ver oq ta errado 
            var gastoSelected = dataGridGastos.SelectedItem as Gasto;

            var window = new CadastroGasto(gastoSelected.Codigo);

            window.ShowDialog();
            LoadDataGrid();

           

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var gastoSelected = dataGridGastos.SelectedItem as Gasto;

            var result = MessageBox.Show($"Deseja realmente remover 0 gasto {gastoSelected.Descricao} ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new GastosDAO();
                    dao.Delet(gastoSelected);
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
