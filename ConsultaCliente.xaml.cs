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
            LoadDataGrid();
        }
        private void LoadDataGrid()
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
  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente2 consulcli = new ConsultaCliente2();
            consulcli.Show();
        }

      
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void btnfechar_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridcli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnnovo_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente cadastrocli = new CadastroCliente();
            cadastrocli.Show();

        }
    }
}
