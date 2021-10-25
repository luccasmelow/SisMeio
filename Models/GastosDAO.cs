using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Sismeio.Interfaces;
using Sismeio.Base;


namespace Sismeio.Models
{
    class GastosDAO : IDAO<Gasto>
    {
        private static Conexao conn;

        public GastosDAO()
        {
            conn = new Conexao();
        }

        public void Delet(Gasto t)
        {
            throw new NotImplementedException();
        }

        public Gasto GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Insert(Gasto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO gastos (valor_gas, data_gas, descricao, cod_cai_fk)" +
                    "VALUES(@valor, @data, @descricao, @caixa)";

                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@caixa", t.Caixa);

                var result = query.ExecuteNonQuery();

            } catch (Exception e)
            {
                throw e;

            } finally
            {
                conn.Close();
            }

        }

        public List<Gasto> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Gasto t)
        {
            throw new NotImplementedException();
        }

        


    }
}
