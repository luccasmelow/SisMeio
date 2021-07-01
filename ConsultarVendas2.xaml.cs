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
    /// Lógica interna para ConsultarVendas2.xaml
    /// </summary>
    public partial class ConsultarVendas2 : Window
    {
        public ConsultarVendas2()
        {
            InitializeComponent();
            Loaded += ConsultarVendas2_Loaded;
        }
        private void ConsultarVendas2_Loaded(object sender, RoutedEventArgs e)
        {
            List<Vendas> listavendas = new List<Vendas>();



            listavendas.Add(new Vendas()
            {
                Codigo = 001,
                Produtos = "Chinelo Vermelho",
                Categoria = "Feminino",
                Marca = "Ramarin",
                Quantidade = 1,
                Valor = 49.90,
                Valoruni=49.90
              
 

            }); dataGridVendas2.ItemsSource = listavendas;
        }
            private void bttfechar_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
     }
 }

