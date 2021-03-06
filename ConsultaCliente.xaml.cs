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
    /// Lógica interna para ConsultaCliente.xaml
    /// </summary>
    public partial class ConsultaCliente : Window
    {
        public ConsultaCliente()
        {
            InitializeComponent();
            Loaded += ConsultaCliente_Loaded;
        }

        private void ConsultaCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ClienteDAO();

                dataGridcli.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVisualizar_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridcli.SelectedItem as Cliente;

            var window = new CadastroCliente(clienteSelected.Codigo);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void dataGridcli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnexcluir_Click(object sender, RoutedEventArgs e)
        {
            var clientSelected = dataGridcli.SelectedItem as Cliente;


            var result = MessageBox.Show($"Deseja realmente excluir o cliente `{clientSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delet(clientSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastroCliente();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void btnfechar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja fechar esta janela?", "Sucesso", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)

                this.Close();
        }
    }
}
