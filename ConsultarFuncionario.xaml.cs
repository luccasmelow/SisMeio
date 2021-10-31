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
    /// Lógica interna para ConsultarFuncionario.xaml
    /// </summary>
    public partial class ConsultarFuncionario : Window
    {
        public ConsultarFuncionario()
        {
            InitializeComponent();
            Loaded += ConsultarFuncionario_Loaded;
        }

        private void ConsultarFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new FuncionarioDAO();

                dataGridcli.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridcli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btcadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarFuncionario();
            window.Owner = this;
            window.ShowDialog();
        }

        private void btcancelar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja fechar esta janela?", "Sucesso", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)

                this.Close();
        }

        private void btnovo_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarFuncionario();
            window.Owner = this;
            window.ShowDialog();
        }

        private void btexcluir_Click(object sender, RoutedEventArgs e)
        {

            var funcionarioSelected = dataGridcli.SelectedItem as Funcionario;


            var result = MessageBox.Show($"Deseja realmente excluir o Funcionario `{funcionarioSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delet(funcionarioSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
