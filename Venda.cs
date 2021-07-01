using System;
using System.Collections.Generic;
using System.Text;

namespace Sismeio
{
    public class Venda
    {
       
        public int id_venda { get; set; }

        public String pagamento { get; set; }

        public Produto produto { get; set; }

        public Cliente cliente  { get; set; }





    }
}
