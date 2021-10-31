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
            

            _caixa= new Caixa();

            if (_cod > 0)
                FillForm();


        }

        private bool Validate()
        {
            var validator = new CaixaValidator();

            var caixa = new Caixa();

            var result = validator.Validate(caixa);

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

            Caixa caixa = new Caixa();
            
            /*
            caixa.Mes = txtMes.Text;
            caixa.SaldoAnt = Convert.ToDouble(txtSaldoAn.Text);
            caixa.SaldoFin = Convert.ToDouble(txtSaldoFin.Text);
            caixa.Creditos = Convert.ToDouble(txtCreditos.Text);
            caixa.Debitos = Convert.ToDouble(txtDebitos.Text);
            */
            
            // if (txtMes.Text, out string mes)
            //_caixa.Mes = mes;
                        
            if (txtMes.Text != null)
                caixa.Mes = txtMes.Text;
            if (txtSaldoAn.Text != null)
                caixa.SaldoAnt = Convert.ToDouble(txtSaldoAn.Text);
            if (txtSaldoFin.Text!= null)
                caixa.SaldoFin = Convert.ToDouble(txtSaldoFin.Text);
            if (txtDebitos.Text != null)
                caixa.Debitos = Convert.ToDouble(txtDebitos.Text);
            if (txtCreditos.Text != null)
                caixa.Creditos = Convert.ToDouble(txtCreditos.Text);
            
            
            SalveData();

        }

       
        private void SalveData()
        {
            Caixa caixa = new Caixa();

            try
            {
                if (Validate())
                {
                    CaixaDAO dao = new CaixaDAO();
                    var text = "atualizado";

                    if (caixa.Codigo == 0)
                    {
                        dao.Insert(caixa);
                        text = "adicionado";
                    }
                    else
                        dao.Update(caixa);

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
            Caixa caixa = new Caixa();
            try
            {
                var dao = new CaixaDAO();
                caixa = dao.GetById(_cod);

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
            Caixa caixa = new Caixa();
            if (caixa.Codigo == 0)
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
