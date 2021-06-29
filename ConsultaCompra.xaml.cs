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
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Cliente> listacliente = new List<Cliente>();

            for (int i = 0; i < 10; i++)
            {

                listacliente.Add(new Cliente()
                {
                    codigo = i + 1,
                    nome = "João Alves" + i,
                    situacao = "Devedor"
                });
            }
        
        }
    }
}
