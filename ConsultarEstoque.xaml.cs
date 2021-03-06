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
using Sismeio.Models;



namespace Sismeio
{
    /// <summary>
    /// Lógica interna para ConsultarEstoque.xaml
    /// </summary>
    public partial class ConsultarEstoque : Window
    {

        public ConsultarEstoque()
        {
            InitializeComponent();
            Loaded += ConsultarEstoque_Loaded;
        }



        private void ConsultarEstoque_Loaded(object sender, RoutedEventArgs e)
        {

            LoadDataGrid();
        }


        /* private void LoadList ()
         {
             try
             {
                 var dao = new ProdutoDAO();
                 dataGridEstoque.ItemsSource = dao.List(); 
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
             }
         }*/

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ProdutoDAO();

                dataGridEstoque.ItemsSource = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = dataGridEstoque.SelectedItem as Produto;

            var window = new CadastroProduto(produtoSelected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }

        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastroProduto();
            window.ShowDialog();
            LoadDataGrid();


        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = dataGridEstoque.SelectedItem as Produto;
            var result = MessageBox.Show($"Deseja realmente remover o produto '{produtoSelected.Nome}' ?", "confirmação de exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
                    dao.Delet(produtoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        //  List<Produto> ListaEstoque = new List<Produto>();


        //ListaEstoque.Add(new Produto()
        //{
        //  Id = 001,
        //Descricao = "Chinelo Vermelho",
        //Categoria = "Chinelo",
        // Quantidade = 2,
        //ValorUnitario = 49.90,
        //ValorEstoque = 99.80,
        //Marca = "Havaiana",
        //Numeracao = 34


        //            });

        //  ListaEstoque.Add(new Produto()
        //{
        //  Id = 009,
        //Descricao = "Chinelo Verde",
        //     Categoria = "Chinelo",
        //   Quantidade = 2,
        // ValorUnitario = 49.90,
        //      ValorEstoque = 99.80,
        //     Marca = "Havaiana",
        //     Numeracao = 34


        //   });

        //   ListaEstoque.Add(new Produto()
        //{
        //     Id = 002,
        //  Descricao = "Sandália Dourada",
        //Categoria = "Sandália",
        //   Quantidade = 3,
        //     ValorUnitario = 99.90,
        //ValorEstoque = 299.70,
        // Marca = "Ramarim",
        // Numeracao = 37


        //});

        //ListaEstoque.Add(new Produto()
        //  {
        //   Id = 005,
        //     Descricao = "Sandália Rosa",
        //     Categoria = "Sandália",
        //   Quantidade = 1,
        //   ValorUnitario = 99.90,
        //   ValorEstoque = 99.90,
        //    Marca = "Ramarim",
        // Numeracao = 39


        //});
        //    ListaEstoque.Add(new Produto()
        //  {
        //    Id = 012,
        //     Descricao = "Sandália Rosa",
        //    Categoria = "Sandália",
        //  Quantidade = 1,
        //  ValorUnitario = 99.90,
        //  ValorEstoque = 99.90,
        //  Marca = "Ramarim",
        //  Numeracao = 35


        //  });

        //   ListaEstoque.Add(new Produto()
        // {
        //   Id = 008,
        //   Descricao = "Tênia Preto",
        //   Categoria = "Tênis",
        //  Quantidade = 5,
        //  ValorUnitario = 300.00,
        // ValorEstoque = 1.500,
        // Marca = "Adidas",
        // Numeracao = 39


        //    });



        //  dataGridEstoque.ItemsSource = ListaEstoque;

    }
}
