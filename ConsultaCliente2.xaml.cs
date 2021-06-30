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
    /// Lógica interna para ConsultaCliente2.xaml
    /// </summary>
    public partial class ConsultaCliente2 : Window
    {
        public ConsultaCliente2()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComprasPagas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CadastroProduto cadprod = new CadastroProduto();
            cadprod.Show();
        }

        private void ComprasPendentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
