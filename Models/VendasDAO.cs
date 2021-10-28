using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using Sismeio.Base;

namespace Sismeio.Models
{
    class VendasDAO : IDAO<Vendas>
    {

        private static Conexao conn;

        public VendasDAO()
        {
            conn = new Conexao();
        }

        public void Delet(Vendas t)
        {
            throw new NotImplementedException();
        }

        public Vendas GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vendas t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = " INSERT INTO valor_ven, quantipro_ven, desconto_ven, formapagamento_ven " +
                    "VALUES (@valor_ven, @quantpro_ven, @desconto_ven, @formapagamento_ven)";

                query.Parameters.AddWithValue("@valor_ven", t.Valor);
                query.Parameters.AddWithValue("@quantipro_ven", t.Quantidade);
                query.Parameters.AddWithValue("@desconto_ven", t.Desconto);
                query.Parameters.AddWithValue("@formapagamento_ven", t.FormaPagamento);

                var result = query.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            } 
        }

        public List<Vendas> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Vendas t)
        {
            throw new NotImplementedException();
        }
    }
}
