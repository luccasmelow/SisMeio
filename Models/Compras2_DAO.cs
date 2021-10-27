using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using Sismeio.Base;
using MySql.Data.MySqlClient;
using Sismeio.Models;

namespace Sismeio.Models 
{
    class Compras2_DAO : IDAO<Compras2>
    {

        private static Conexao conec;
      

        public Compras2_DAO()
        {
            conec = new Conexao();

        }
        public void Delet(Compras2 t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "DELETE FROM compras WHERE cod_cli = @id"; 

                query.Parameters.AddWithValue("@id", t.Codigo);
        

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

        public Compras2 GetById(int codigo)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "SELECT * FROM compras WHERE cod_cli = @codigo";

                query.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows )
                {
                    throw new Exception("Nenhum registro encontrado!");
                }

                var compras2 = new Compras2();

                while (reader.Read())
                {

                    Compras2.código = reader.getint32 ("cod_com");
                    Compras2.valor = reader.Getint32 ("valor_com")
                    Compras2.quantidadepro = reader.GetString("quantpro_com");
                    Compras2.data = reader.GetString("data_com");
                    Compras2.frete = reader.GetString("frete_com");
                    Compras2.códigofor = reader.GetDateTime("cod_for_fk");
                    Compras2.dataentrega = reader.GetDateTime("data_entreg_com");
                    Compras2.códigocai = reader.GetDateTime("cod_cai_fk");

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

        public void Insert(Compras2 t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "INSERT INTO compras (nome_cli, cpf_cli, rg_cli, data_nasc_cli, telefone_cli, situacao_cli, historico_cli)" +
                    " VALUES (@nome, @cpf, @rg, @data_nasc, @telefone, @situacao, @historico)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento.ToString("yyyy-MM-dd")); //'18/02/2020 -> '2020/02/18' 
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@situacao", t.Situacao);
                query.Parameters.AddWithValue("@historico", t.Historico);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Tente novamente");


            }
            catch (Exception e)
            {
                throw e;
            }finally
            {
                conec.Close();
            }
        }

        public List<Compras2> List()
        {
            try
            {
                List<Compras2> list = new List<Compras2>();
                var query = conec.Query();
                query.CommandText = "SELECT * FROM compras";

               MySqlDataReader reader = query.ExecuteReader();

                while (reader .Read())
                {
                    list.Add(new Compras2()
                    {
                        Codigo = reader.GetInt32("cod_com"),
                        Valor = reader.GetString("valor_com"),
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

        public void Update(Compras2 t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = " UPDATE compras SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, data_nasc_cli = @data_nasc, telefone_cli = @telefone, situacao_cli =  @situacao, historico_cli = @historico WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento.ToString("yyyy-MM-dd")); //'18/02/2020 -> '2020/02/18'
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@situacao", t.Situacao);

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
