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
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Loaded += RelatorioAP_Loaded;
        }
        private void RelatorioAP_Loaded(object sender, RoutedEventArgs e)
        {
            List<Produto> ListaEstoque = new List<Produto>();


            ListaEstoque.Add(new Produto()
            {
                Id = 001,
                Marca = "Havaiana",
                Descricao = "Chinelo",

                ValorUnitario = 49.90,
                Quantidade = 2,
                Numeracao = 34

            }) ;

            ListaEstoque.Add(new Produto()
            {
                Id = 009,
                Marca = "Havaiana",
                Descricao = "Chinelo Verde",
             
               
                ValorUnitario = 49.90,

                Quantidade = 2,
                Numeracao = 34


            });
            dataGridRelatorio.ItemsSource = ListaEstoque;
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream:Projeto/Login.xaml.cs
            var window = new TelaInicial();

            window.Owner = this;
            window.ShowDialog();
=======
            this.Close();
        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Essa ação não está disponível. O Banco de Dados está em desenvolvimento", "AÇÃO INVÁLIDA", MessageBoxButton.OK);
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarProduto ap = new AtualizarProduto();
            ap.Show();
>>>>>>> Stashed changes:RelatorioAP.xaml.cs
        }
    }
}
