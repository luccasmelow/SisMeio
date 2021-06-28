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
    /// Lógica interna para ConsultaCliente.xaml
    /// </summary>
    public partial class ConsultaCliente : Window
    {
        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente2 consulcli = new ConsultaCliente2();
            consulcli.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CadastroCliente cadastrocli = new CadastroCliente();
            cadastrocli.Show();
        }

        private void dataGridCliente_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
