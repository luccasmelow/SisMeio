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
                    "VALUES (@logradouro_end, @numero_end, @bairro_end, @cidade_end, @estado_end)";

                query.Parameters.AddWithValue("@logradouro_end", t.Logradouro);
                query.Parameters.AddWithValue("@numero_end", t.Numero);
                query.Parameters.AddWithValue("@bairro_end", t.Bairro);
                query.Parameters.AddWithValue("@cidade_end", t.Cidade);
                query.Parameters.AddWithValue("@estado_end", t.Estado);

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
                query.CommandText = "UPDATE endereco SET logradouro = @logradouro_end, numero = @numero_end, bairro = @bairro_end, " +
                            "cidade = @cidade_end, estado = @estado_end  WHERE cod_end = @id_endereco ";

                query.Parameters.AddWithValue("@logradouro_end", t.Logradouro);
                query.Parameters.AddWithValue("@numero_end", t.Numero);
                query.Parameters.AddWithValue("@bairro_end", t.Bairro);
                query.Parameters.AddWithValue("@cidade_end", t.Cidade);
                query.Parameters.AddWithValue("@estado_end", t.Estado);

                query.Parameters.AddWithValue("@id_endereco", t.Codigo);

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
