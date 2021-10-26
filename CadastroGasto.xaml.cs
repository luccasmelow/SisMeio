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


        }


        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
           
                
            _gasto.Valor = Convert.ToDouble(txtValor.Text);
            _gasto.Data = (DateTime)dtPickerDataGasto.SelectedDate;
            _gasto.Descricao = txtDescricao.Text;
            _gasto.Caixa = Convert.ToInt32(txtCaixa.Text);



            SalveData();


              
                
                

            
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SalveData()
        {
            try
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
                txtCaixa.Text = _gasto.Caixa.ToString();



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
            txtCaixa.Text = "";

        }


    }
}
