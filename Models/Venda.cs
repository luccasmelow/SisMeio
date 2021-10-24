using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Models;

namespace Sismeio.Models
{
    public class Venda
    {
       

        public int id_venda { get; set; }

        public int valor_total{ get; set; }

        public String pagamento { get; set; }

        public Produto produto { get; set; }

        public Cliente cliente{ get; set; }





    }
}
