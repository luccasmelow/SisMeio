using System.Windows;
using System.Windows.Controls;

namespace Sismeio
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        public CadastroCliente()
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AtualizarProduto atualizar = new AtualizarProduto();
            atualizar.Show();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

       private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
         
        }
        private void bttfechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
