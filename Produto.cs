using System;
using System.Collections.Generic;
using System.Text;

namespace Sismeio
{
    public class Produto
    {
        public int Id { get; set; }

        public int CodBarras { get; set; }

        public DateTime Importacao { get; set; }

        public DateTime Entrega{ get; set; }

        public String Fornecedor{ get; set; }

        public String Categoria { get; set; }

        public int Numeracao { get; set; }

        public String Marca{ get; set; }

        public int Quantidade { get; set; }

        public double Peso { get; set; }

        public String Descricao { get; set; }

        public double ValorEstoque { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorFrete { get; set; }

        public double Descontos { get; set; }

        public double ValorDespesa{ get; set; }

        public string Despesa { get; set; }

        public string SugestaoValor { get; set; }

        public string SugestaoDesconto { get; set; }

       












    }
}
