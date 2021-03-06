using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using Sismeio.Base;
using MySql.Data.MySqlClient;
using Sismeio.Models;
using Sismeio.Helpers;

namespace Sismeio.Models 
{
    class ClienteDAO : IDAO<Cliente>
    {

        private static Conexao conec;
      

        public ClienteDAO()
        {
            conec = new Conexao();

        }
        public void Delet(Cliente t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "DELETE FROM cliente WHERE cod_cli = @codigo"; 

                query.Parameters.AddWithValue("@codigo", t.Codigo);
        

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi excluído. Tente Novamente!");


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conec.Close();
            }
        }

        public Cliente GetById(int codigo)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "SELECT * FROM cliente LEFT JOIN endereco ON cod_end_fk WHERE cod_cli = @codigo";

                query.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows )
                {
                    throw new Exception("Nenhum registro encontrado!");
                }

                var cliente = new Cliente();

                while (reader.Read())
                {

                    cliente.Codigo = reader.GetInt32("cod_cli");
                    cliente.Nome = reader.GetString("nome_cli");
                    cliente.RG = reader.GetString("rg_cli");
                    cliente.CPF = reader.GetString("cpf_cli");
                    cliente.Telefone = reader.GetString("telefone_cli");
                    cliente.DataNascimento = reader.GetDateTime("data_nasc_cli");

                    if (!DAOHelper.IsNull(reader, "cod_end_fk"))
                        cliente.Endereco = new Endereco()
                        {
                            Codigo = reader.GetInt32("cod_end"),
                            Logradouro = reader.GetString("logradouro"),
                            Numero = reader.GetInt32("numero"),
                            Bairro = reader.GetString("bairro"),
                            Cidade = reader.GetString("cidade"),
                            Estado = reader.GetString("estado")
                        };
                }
                return cliente;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }


        }

        public void Insert(Cliente t)
        {
            try
            {
                var enderecoCod = new EnderecoDAO().Insert(t.Endereco);
                var query = conec.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli, cpf_cli, rg_cli, data_nasc_cli, telefone_cli, cod_end_fk)" +
                " VALUES (@nome, @cpf, @rg, @data_nasc, @telefone, @endereco)";

                //query.CommandText = "CALL Inserir_Cliente(@nome, @rg, @cpf, @nascimento, @telefone, @enderecoCod)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento.ToString("yyyy-MM-dd")); //'18/02/2020 -> '2020/02/18' 
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@endereco", enderecoCod);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");

                /* MySqlDataReader reader = query.ExecuteReader();

                 while(reader.Read())
                 {
                     if(reader.GetName(0).Equals("Alerta"))
                     {
                         throw new Exception(reader.GetString("Alerta"));
                     }
                 }
                */
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conec.Close();
            }
        }

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();
                var query = conec.Query();
                query.CommandText = "SELECT * FROM cliente";

               MySqlDataReader reader = query.ExecuteReader();

                while (reader .Read())
                {
                   
                    list.Add(new Cliente()
                    {
                        Codigo = reader.GetInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        RG = reader.GetString("rg_cli"),
                        CPF = reader.GetString("cpf_cli"),
                        Telefone = reader.GetString("telefone_cli"),
                        DataNascimento = reader.GetDateTime("data_nasc_cli")


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
                conec.Close();
            }
        }

        public void Update(Cliente t)
        {
            try
            {
                long enderecoCod = t.Endereco.Codigo;
                var endDAO = new EnderecoDAO();

                if (enderecoCod > 0)
                    endDAO.Update(t.Endereco);
                else
                    enderecoCod = endDAO.Insert(t.Endereco);

                var query = conec.Query();
                query.CommandText = " UPDATE cliente SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, data_nasc_cli = @data_nasc, telefone_cli = @telefone,  cod_end_fk = @enderecoCod  WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento.ToString("yyyy-MM-dd")); //'18/02/2020 -> '2020/02/18'
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@enderecoCod", enderecoCod);

                query.Parameters.AddWithValue("@id", t.Codigo);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi atualizado. Tente novamente");


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conec.Close();
            }
        }
    }
}
