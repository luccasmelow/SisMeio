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
    /// Lógica interna para CadastroProduto.xaml
    /// </summary>
   
    
        public partial class CadastroProduto : Window
        {
            private int _id;
            private Produto _produto;
            public CadastroProduto()
            {
                InitializeComponent();
                Loaded += CadastroProduto_Loaded;
            }
            public CadastroProduto(int id)
            {
                _id = id;
                InitializeComponent();
                Loaded += CadastroProduto_Loaded;
            }

            private void CadastroProduto_Loaded(object sender, RoutedEventArgs e)
            {

                _produto = new Produto();

                if (_id > 0)
                    fillform();
            }



            private void btnSalvar_Click(object sender, RoutedEventArgs e)
            {


                Produto produto = new Produto();

                _produto.Marca = txtMarca.Text;
                _produto.Nome = txtNome.Text;
                _produto.Numeracao = Convert.ToInt16(txtNumeracao.Text);
                _produto.Peso = Convert.ToDouble(txtPeso.Text);
                _produto.ValorUnitario = Convert.ToDouble(txtValUnit.Text);
                _produto.ValorEstoque = Convert.ToDouble(txtValEstq.Text);
                _produto.Entrega = (DateTime)dtPickerEnt.SelectedDate;
                _produto.Importacao = (DateTime)dtPickerImport.SelectedDate;
                _produto.Descricao = txtDescricao.Text;
                _produto.Categoria = txtCategoria.Text;



                Save();


            }
            private bool Validate()
            {
                var validator = new ProdutoValidator();
                var result = validator.Validate(_produto);

                if (result.IsValid)
                {
                    string errors = null;
                    var count = 1;

                    foreach (var failure in result.Errors)
                    {
                        errors += $"{count++} - {failure.ErrorMessage} \n";

                    }
                   
                }
                return result.IsValid;
            }



            private void Save()
            {
                try
                {


                    if (Validate())
                    {
                        var dao = new ProdutoDAO();
                        var text = "atualizado";
                        if (_produto.Id == 0)
                        {
                            dao.Insert(_produto);
                            text = "adicionado";
                        }
                        else
                            dao.Update(_produto);

                        MessageBox.Show($"O produto foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        CloseForm();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Não executado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }



            private void fillform()
            {
                try
                {

                    var dao = new ProdutoDAO();
                    _produto = dao.GetById(_id);

                    txtCodP.Text = _produto.Id.ToString();
                    txtNome.Text = _produto.Nome;
                    txtNumeracao.Text = _produto.Numeracao.ToString();
                    txtPeso.Text = _produto.Peso.ToString();
                    txtValUnit.Text = _produto.ValorUnitario.ToString("C");
                    txtValEstq.Text = _produto.ValorEstoque.ToString("C");
                    dtPickerEnt.SelectedDate = _produto.Entrega;
                    dtPickerImport.SelectedDate = _produto.Importacao;
                    txtDescricao.Text = _produto.Descricao;
                    txtCategoria.Text = _produto.Categoria;
                txtMarca.Text = _produto.Marca;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Excessão", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }



            private void CloseForm()
            {
                if (_produto.Id == 0)
                {
                    var result = MessageBox.Show("Deseja continuar cadastrando outros produtos ?", "Continuar ?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.No)
                    {
                        this.Close();
                    }
                    else
                        ClearInputs();
                }
                else
                    this.Close();
            }
            private void ClearInputs()
            {
                txtNome.Text = "";
                txtNumeracao.Text = "";
                txtPeso.Text = "";
                txtValUnit.Text = "";
                txtValEstq.Text = "";
                dtPickerEnt.SelectedDate = null;
                dtPickerImport.SelectedDate = null;
                txtDescricao.Text = "";
                txtCategoria.Text = "";

            }

            private void btnCancelar_Click(object sender, RoutedEventArgs e)
            {
                MessageBoxResult result = MessageBox.Show("Deseja realmente cancelar o cadastro ?", "CADASTRAR PRODUTO", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        break;
                }
            }

            private void btnVer_Click(object sender, RoutedEventArgs e)
            {
            var window = new ConsultarEstoque();
            window.ShowDialog();
        }
        }
    }
