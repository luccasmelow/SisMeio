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
using Sismeio.Base;
using Sismeio.Models;


namespace Sismeio
{
    /// <summary>
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnEntrarClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaCliente2();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultarEstoque();

            window.Owner = this;
            window.ShowDialog();


            try
            {
                var conexao = new Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGestaoDeGastos_Click(object sender, RoutedEventArgs e)
        {
            var window = new ControlarGastos();

            window.Owner = this;
            window.ShowDialog();


           //Insert_Teste();

            Insert_Teste();

        }

        private void btnFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarFuncionario();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnNovaVenda_Click(object sender, RoutedEventArgs e)
        {
            var window = new RealizarVendas();

            window.Owner = this;
            window.ShowDialog();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaCliente2();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnTrocarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var window = new Login();

            window.Owner = this;
            window.ShowDialog();
        }

        
        private void BtnGestaoControle_Click(object sender, RoutedEventArgs e)
        {
            var window = new ControlarGastos();

            window.Owner = this;
            window.ShowDialog();
        }
        



        private void BtnCadastroClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastroCliente();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastroProduto();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnCadastroFuncionario_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarFuncionario();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnConsultarClientes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaCliente();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnConsultarFuncioanrios_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultarFuncionario();

            window.Owner = this;
            window.ShowDialog();
        }

        private void BtnConsultarProdutos_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConsultarEstoque();

            window.Owner = this;
            window.ShowDialog();
        }

        private void Insert_Teste()
        {
            /*
            try
            {
                Gasto gastos = new Gasto();
                gastos.Valor = 58.4;
                gastos.Data = DateTime.Now;
                gastos.Descricao = "Agua";
                gastos.Caixa = 2;


                GastosDAO gastosDAO = new GastosDAO();
                gastosDAO.Insert(gastos);

                MessageBox.Show("Gasto cadastrado com sucesso", "Sucesso", MessageBoxButton.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            */


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
