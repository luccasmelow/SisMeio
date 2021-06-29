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
    /// Lógica interna para RelatorioAP.xaml
    /// </summary>
    public partial class RelatorioAP : Window
    {
        public RelatorioAP()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarProduto atualprod = new AtualizarProduto();
            atualprod.Show();
        }
    }
}
