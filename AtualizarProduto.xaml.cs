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
    /// Lógica interna para AtualizarProduto.xaml
    /// </summary>
    public partial class AtualizarProduto : Window
    {
        public AtualizarProduto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Atualização feita com sucesso", "ATUALIZAÇÃO", MessageBoxButton.OK);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente cancelar a atualização ?", "ATUALIZAR PRODUTO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            txtMarca.Text = "";
            txtQtd.Text = "";
            txtCat.Text= "";
            txtNum.Text = "";
            txtEstoq.Text= "";
            txtUnit.Text="";
            txtFrete.Text="";
            txtDesconto.Text = "";
             
        }
    }
}
