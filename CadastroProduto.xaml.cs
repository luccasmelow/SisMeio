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
    /// Lógica interna para CadastroProduto.xaml
    /// </summary>
    public partial class CadastroProduto : Window
    {
        public CadastroProduto()
        {
            InitializeComponent();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AtualizarProduto atua = new AtualizarProduto();
            atua.Show();
        }
        private void RBSug_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            
        }
        private void RBSug2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Cadastro feita com sucesso", "CADASTRO PRODUTO", MessageBoxButton.OK);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente cancelar o cadastro ?", "CADASTRAR PRODUTO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
        }

        private void bbtnNovo_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            txtCodP.Text = " ";
            txtCodB.Text = "";
            txtFornecedor.Text = "";
            txtDescricao.Text = "";
            txtMarca.Text = "";
            txtPeso.Text = "";
            txtQtdd.Text = "";
            txtValEtq.Text = "";
            txtValUnit.Text = "";
            txtValFrt.Text = "";
            txtValDescon.Text = "";
            txtSugestao.Text = "";
            txtSugestao2.Text = "";
            txtdescrvalor1.Text = "";
            txtdescrvalor2.Text = "";
            

        }

        private void txtPeso_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnImagem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Essa ação ainda não está disponível.", "Opss!", MessageBoxButton.OK);
        }

        private void txtValEtq_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
