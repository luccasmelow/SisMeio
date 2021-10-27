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
            Loaded += ConsultarCliente_Loaded;
        }

        private void ConsultarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGridcli();
        }
        private void LoadDataGridcli()
        {
            try
            {
                var dao = new ClienteDAO();

                dataGridcli.ItemsSource = dao.List();
            
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
      
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void btfechar_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridcli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastroCliente();
            window.ShowDialog();

            LoadDataGridcli();

        }

        private void btnVisualizar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = dataGridcli.SelectedItem as Cliente;

            try
            {
                var dao = new ClienteDAO();
                var cli = dao.GetById(1000);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridcli.SelectedItem as Cliente;

            var result = MessageBox.Show($"Tem certeza que deseja excluir o cliente {clienteSelected.Nome}", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning); 
            
            try
            {
                if(result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delet(clienteSelected);
                    LoadDataGridcli();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

    }
}
