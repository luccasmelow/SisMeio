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
    /// Lógica interna para ConsultaCompra.xaml
    /// </summary>
    public partial class ConsultaCompra : Window
    {
        public ConsultaCompra()
        {
            InitializeComponent();
            Loaded += ConsultaCompra_Loaded;
        }

        private void ConsultaCompra_Loaded(object sender, RoutedEventArgs e)
        {
            List<Compra> listacompra = new List<Compra>();

            for (int i = 0; i < 10; i++)
            {

                listacompra.Add(new Compra()
                {

                    Codigo = 001,
                    Nome = "Chinelo Vermelho",
                    Categoria = "Feminino",
                    Quantidade = 2,
                    Valor = 49.90,
                    Datacompra = "23/09/2020"
                    


                });
             
                listacompra.Add(new Compra()
                {
                    Codigo = 009,
                    Nome = "Chinelo Verde",
                    Categoria = "Feminino",
                    Quantidade = 2,
                    Valor = 99.80,
                    Datacompra = "23/09/2020"


                });

                listacompra.Add(new Compra()
                {
                    Codigo = 002,
                    Nome = "Sandália Dourada",
                    Categoria = "Feminino",
                    Quantidade = 3,
                    Valor = 299.70,
                    Datacompra = "23/09/2020"



                });
            
            } dataGridCompras1.ItemsSource = listacompra;
        
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridCompras1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void bttfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
