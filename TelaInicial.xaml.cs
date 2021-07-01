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
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnEntrarClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaCliente2();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultarEstoque();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnGestaoDeGastos_Click(object sender, RoutedEventArgs e)
        {
            var window = new ControlarGastos();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarFuncionario();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnNovaVenda_Click(object sender, RoutedEventArgs e)
        {
            var window = new RealizarVendas();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaCliente2();

            window.Owner = this;
            window.ShowDialog();
        }
    }
    
}
