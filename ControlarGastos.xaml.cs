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
    /// Lógica interna para ControlarGastos.xaml
    /// </summary>
    public partial class ControlarGastos : Window
    {
        public ControlarGastos()
        {
            InitializeComponent();
        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ControlarGastos_Loaded(object sender, RoutedEventArgs e)
        {
            List<Despesa> ListaGastos = new List<Despesa>();


            ListaGastos.Add(new Despesa()
            {
                id= 0158,
                descricao = "Conta de Energia",
                Valor = 500.97


            });

           


            dataGridGastos.ItemsSource = ListaGastos;
        }
    }
}
