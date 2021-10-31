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
        private int _cod;

        private Gasto _gasto; 


        public CadastroGasto()
        {
            InitializeComponent();
            Loaded += CadastroGasto_Loaded;
        }

        public CadastroGasto(int codigo)
        {
            _cod = codigo;
            InitializeComponent();
            Loaded += CadastroGasto_Loaded;
        }

        private void CadastroGasto_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(_cod.ToString()); ---> usar p teste

            _gasto = new Gasto();

            if (_cod > 0)
                FillForm();

            cbCaixa.ItemsSource = new CaixaDAO().List();


        }


        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
           
             
            _gasto.Valor = Convert.ToDouble(txtValor.Text);
            //_gasto.Data = (DateTime)dtPickerDataGasto.SelectedDate;
             _gasto.Descricao = txtDescricao.Text;
            if (dtPickerDataGasto.SelectedDate != null)
                _gasto.Data = (DateTime)dtPickerDataGasto.SelectedDate;

            if (cbCaixa.SelectedItem != null)
                 _gasto.Caixa = cbCaixa.SelectedItem as Caixa;

            //  if (double.TryParse(txtValor.Text, out double valor))
            // _gasto.Valor = valor;


           



          


            SalveData();


            
        }

        private bool Validate()
        {
            var validator = new GastoValidator();

            var result = validator.Validate(_gasto);

            if(!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";

                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SalveData()
        {
            try
            {
                if (Validate())
                {
                    GastosDAO dao = new GastosDAO();
                    var text = "atualizado";

                    if (_gasto.Codigo == 0)
                    {
                        dao.Insert(_gasto);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_gasto);

                    MessageBox.Show($"Gasto {text} com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
                

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void FillForm()
        {

            try
            {
                var dao = new GastosDAO();
                _gasto = dao.GetById(_cod);

                txtCodigo.Text = _gasto.Codigo.ToString();
                txtValor.Text = _gasto.Valor.ToString();
                dtPickerDataGasto.SelectedDate = _gasto.Data;
                txtDescricao.Text = _gasto.Descricao;
                

                if (_gasto.Caixa != null)
                    cbCaixa.SelectedValue = _gasto.Caixa.Codigo;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CloseFormVerify()
        {
            if (_gasto.Codigo == 0)
            {
                var result = MessageBox.Show("Deseja prosseguir com o cadastro de gastos?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)

                    this.Close();

                else
                    ClearInputs();
            }
            else
                this.Close();
        }
        private void ClearInputs()
        {
          
           
            txtValor.Text ="";
            dtPickerDataGasto.SelectedDate = null;
            txtDescricao.Text = "";
            cbCaixa.Text = "";

        }


    }
}
