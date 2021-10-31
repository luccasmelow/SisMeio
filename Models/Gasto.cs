using System;
using System.Collections.Generic;
using System.Text;

namespace Sismeio.Models
{
    public class Gasto
    {
        public int Codigo { get; set; }

        public double Valor { get; set; }
        public DateTime? Data { get; set; }

        public string Descricao  { get; set; }

        public Caixa Caixa { get; set; }





    }
}
