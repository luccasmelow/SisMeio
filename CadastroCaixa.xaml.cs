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
    /// Lógica interna para CadastroCaixa.xaml
    /// </summary>
    public partial class CadastroCaixa : Window
    {
        private int _cod;

        private Caixa _caixa;
        public CadastroCaixa()
        {
            InitializeComponent();
        }
        public CadastroCaixa(int codigo)
        {
            _cod = codigo;
            InitializeComponent();
            Loaded += CadastroCaixa_Loaded;
        }
        private void CadastroCaixa_Loaded(object sender, RoutedEventArgs e)
        {
            

            _caixa = new Caixa();

            if (_cod > 0)
                FillForm();


        }

        private bool Validate()
        {
            var validator = new CaixaValidator();

            var result = validator.Validate(_caixa);

            if (!result.IsValid)
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

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
            _caixa.Mes = txtMes.Text;
            _caixa.SaldoAnt = Convert.ToDouble(txtSaldoAn.Text);
            _caixa.SaldoFin = Convert.ToDouble(txtSaldoFin.Text);
            _caixa.Creditos = Convert.ToDouble(txtCreditos.Text);
            _caixa.Debitos = Convert.ToDouble(txtDebitos.Text);

            SalveData();


        }
        private void SalveData()
        {
            try
            {
                if (Validate())
                {
                    CaixaDAO dao = new CaixaDAO();
                    var text = "atualizado";

                    if (_caixa.Codigo == 0)
                    {
                        dao.Insert(_caixa);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_caixa);

                    MessageBox.Show($"Caixa {text} com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void FillForm()
        {

            try
            {
                var dao = new CaixaDAO();
                _caixa = dao.GetById(_cod);

                txtCodigo.Text = _caixa.Codigo.ToString();
                txtMes.Text = _caixa.Mes.ToString();
                txtSaldoAn.Text = _caixa.SaldoAnt.ToString();
                txtSaldoFin.Text = _caixa.SaldoFin.ToString();
                txtCreditos.Text = _caixa.Debitos.ToString();
                txtDebitos.Text = _caixa.Creditos.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CloseFormVerify()
        {
            if (_caixa.Codigo == 0)
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


            txtCodigo.Text = "";
            txtMes.Text = "";
            txtSaldoAn.Text = "";
            txtSaldoFin.Text = "";
            txtCreditos.Text = "";
            txtDebitos.Text = "";

        }

    }
}
