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
    /// Lógica interna para ConsultarCompra2.xaml
    /// </summary>
    public partial class ConsultarCompra2 : Window
    {
        public ConsultarCompra2()
        {
            InitializeComponent();
            Loaded += ConsultarCompras2_Loaded;
        }

        private void ConsultarCompras2_Loaded(object sender, RoutedEventArgs e)
        {
            List<Compras2> listacompra2 = new List<Compras2>();


            listacompra2.Add(new Compras2()
            {
                Codigo = 001,
                Nome = "Chinelo Vermelho",
                Categoria = "Feminino",
                Quantidade = 2,
                ValorUnitario = 49.90,
                ValorTotal = 99.80,
                Marca = "Havaiana",
                Numeracao = 34


            });

            dataGridCompras2.ItemsSource = listacompra2;
        }
    }

    
        private void bttfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
   
}



