using System;
using System.Windows;
using System.Windows.Controls;
using Sismeio.Models;
using Sismeio.Base;
using Sismeio.Helprs;


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
            Loaded += CadastrarFuncionario_Loaded;
        }

        private void CadastrarFuncionario_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btcadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.CPF = txtCpf.Text;
                funcionario.RG = txtRg.Text;
                funcionario.Sexo = txtSexo.Text;
                funcionario.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;
                funcionario.Salario = Convert.ToDouble(txtSalario.Text);
                funcionario.Setor = txtSetor.Text;
                funcionario.DataAdmissao = (DateTime)dtPickerDataAdmissao.SelectedDate;
                funcionario.Telefone = txtTelefone.Text;

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(funcionario);

                funcionario.Endereco = new Endereco();
                funcionario.Endereco.Logradouro = txtLogradouro.Text;
                funcionario.Endereco.Bairro = txtBairro.Text;
                funcionario.Endereco.Cidade = txtCidade.Text;
                
                if (int.TryParse(txtNumero.Text, out int numero))
                    funcionario.Endereco.Numero = numero;

                if (comboBoxEstado.SelectedItem != null)
                    funcionario.Endereco.Estado = comboBoxEstado.SelectedItem as string;


                MessageBox.Show("O Funcionário foi adicionado com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void txtSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
        }


        private void LoadComboBox()
        {
            try
            {
                comboBoxEstado.ItemsSource = Estado.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
