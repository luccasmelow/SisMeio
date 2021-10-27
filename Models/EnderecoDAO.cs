using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismeio.Base;

namespace Sismeio.Models
{
    class EnderecoDAO
    {
        private static Conexao conec = new Conexao();
        public long Insert(Endereco t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "INSERT INTO endereco (logradouro, numero, bairro, cidade, estado) " +
                    "VALUES (@logradouro, @numero, @bairro, @cidade, @estado)";

                query.Parameters.AddWithValue("@rua", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@estado", t.Estado);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao cadastrar o endereço. Tente Novamente!");

                return query.LastInsertedId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Endereco t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "UPDATE endereco SET logradouro = @logradouro, numero = @numero, bairro = @bairro, " +
                            "cidade = @cidade, estado = @estado  WHERE cod_end = @codigo ";

                query.Parameters.AddWithValue("@rua", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@estado", t.Estado);

                query.Parameters.AddWithValue("@id", t.Codigo);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao atualizar o endereço. Tente Novamente!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
