using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismeio.Interfaces;
using Sismeio.Base;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sismeio.Models
{

    class ProdutoDAO : IDAO <Produto>
    {
        private static Conexao conn;

        public ProdutoDAO()
        {
            conn = new Conexao();
        }

        public void Delet(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM produto WHERE cod_pro = @id ";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Registro não foi removido. Verifique e tente novamente");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        
        public Produto GetById(int Id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto WHERE cod_pro = @id";
                query.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado");

                var produto = new Produto();

                while (reader.Read())
                {

                    produto.Id = reader.GetInt32("cod_pro");
                    produto.Nome = reader.GetString("nome_pro");
                    produto.Categoria = reader.GetString("categoria_pro");
                    produto.Numeracao = reader.GetInt32("numeracao_pro");
                    produto.Descricao = reader.GetString("descricao_pro");

                    produto.Marca = reader.GetString("marca_prod");
                    produto.Peso = reader.GetDouble("peso_pro");
                    produto.ValorUnitario = reader.GetDouble("preco_pro");
                    produto.Importacao = reader.GetDateTime("data_import");
                    produto.Entrega = reader.GetDateTime("data_entrega");


                }
                return produto;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produto (nome_pro,categoria_pro,numeracao_pro,descricao_pro,estoque_pro,data_import,data_entrega,marca_prod,peso_pro,preco_pro) " +
                "VALUES (@nome, @categoria, @numeracao, @descricao, @estoque, @importacao, @entrega,@marca,@peso,@preco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@categoria", t.Categoria);
                query.Parameters.AddWithValue("@numeracao", t.Numeracao);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@estoque", t.ValorEstoque);
                query.Parameters.AddWithValue("@importacao", t.Importacao);
                query.Parameters.AddWithValue("@entrega", t.Entrega);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@peso", t.Peso);
                query.Parameters.AddWithValue("@preco", t.ValorUnitario);
                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("cod_pro"),
                        Nome = reader.GetString("nome_pro"),
                        Categoria = reader.GetString("categoria_pro"),
                        Numeracao = reader.GetInt32("numeracao_pro"),
                        Descricao = reader.GetString("descricao_pro"),

                        Marca = reader.GetString("marca_prod"),
                        Peso = reader.GetDouble("peso_pro"),
                        ValorUnitario = reader.GetDouble("preco_pro"),
                        Importacao = reader.GetDateTime("data_import"),
                        Entrega = reader.GetDateTime("data_entrega")


                    });

                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();

            }
        }

        public void Update(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE  produto SET nome_pro = @nome,categoria_pro = @categoria," +
                    "numeracao_pro = @numeracao,descricao_pro = @descricao,estoque_pro = @estoque,data_import = @importacao,data_entrega = @entrega" +
                    ",marca_prod = @marca,peso_pro= @peso,preco_pro= @preco " +
                "WHERE cod_pro = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@categoria", t.Categoria);
                query.Parameters.AddWithValue("@numeracao", t.Numeracao);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@estoque", t.ValorEstoque);
                query.Parameters.AddWithValue("@importacao", t.Importacao);
                query.Parameters.AddWithValue("@entrega", t.Entrega);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@peso", t.Peso);
                query.Parameters.AddWithValue("@preco", t.ValorUnitario);
                query.Parameters.AddWithValue("@id", t.Id);
                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }


}
