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
    /// Lógica interna para CadastrarFuncionario.xaml
    /// </summary>
    public partial class CadastrarFuncionario : Window
    {
        public CadastrarFuncionario()
        {
            InitializeComponent();
        }



        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"Cadastro feita com sucesso", "CADASTRO FUNCIONÁRIO", MessageBoxButton.OK);
            this.Close();



        }

    

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente cancelar o cadastro?", "CADASTRAR FUNCIONÁRIO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
        }

        private void cpf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Estado_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
