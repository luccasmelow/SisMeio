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
using Sismeio.Base;

namespace Sismeio
{
    /// <summary>
    /// Lógica interna para CadastroGasto.xaml
    /// </summary>
    public partial class CadastroGasto : Window
    {
        public CadastroGasto()
        {
            InitializeComponent();
        }

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Gasto gastos = new Gasto();
                gastos.Valor = Convert.ToDouble(txtValor.Text);
                gastos.Data = (DateTime)dtPickerDataGasto.SelectedDate;
                gastos.Descricao = txtDescricao.Text;
                gastos.Caixa = Convert.ToInt16(txtValor.Text);


                GastosDAO gastosDAO = new GastosDAO();
                gastosDAO.Insert(gastos);

                MessageBox.Show("Gasto cadastrado com sucesso", "Sucesso", MessageBoxButton.OK);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
