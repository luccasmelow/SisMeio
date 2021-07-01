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
    /// Lógica interna para ConsultarVendas.xaml
    /// </summary>
    public partial class ConsultarVendas : Window
    {
        public ConsultarVendas()
        {
            InitializeComponent();
            Loaded += ConsultarVendas_Loaded;
        }
        private void ConsultarVendas_Loaded(object sender, RoutedEventArgs e)
        {
            List<Vendas> listavendas = new List<Vendas>();



            listavendas.Add(new Vendas()
            {
                Codigo = 001,
                Produtos = "Chinelo Vermelho",
                Valor = 49.90,
                Datavenda = 23 / 10 / 2020


            });

            listavendas.Add(new Vendas()
            {
                Codigo = 009,
                Produtos = "Chinelo Verde",
                Valor = 49.90,
                Datavenda = 23 / 10 / 2020

            });

            listavendas.Add(new Vendas()
            {
                Codigo = 002,
                Produtos = "Sandália Dourada",
                Valor = 99.90,
                Datavenda = 23 / 10 / 2020


            }); dataGridVendas.ItemsSource = listavendas;
        }

            private void btnfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
