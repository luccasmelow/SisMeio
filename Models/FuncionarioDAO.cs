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
    class FuncionarioDAO : IDAO<Funcionario>
    {


        private static Conexao conec;


        public FuncionarioDAO()
        {
            conec = new Conexao();

        }


        public void Delet(Funcionario t)
        {
            throw new NotImplementedException();
        }

        public Funcionario GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var enderecoCod = new EnderecoDAO().Insert(t.Endereco);
                var query = conec.Query();
                query.CommandText = "INSERT INTO funcionario (nome_fun, cpf_fun, rg_fun, sexo_fun, data_nasc_fun, telefone_fun, data_admissao_fun, setor_fun, salario_fun, cod_end_fk)" +
                " VALUES (@nome, @cpf, @rg, @sexo, @data_nasc, @telefone, @data_admissao, @setor, @salario, @endereco)";

                //query.CommandText = "CALL Inserir_Cliente(@nome, @rg, @cpf, @nascimento, @telefone, @enderecoCod)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento.ToString("yyyy-MM-dd")); //'18/02/2020 -> '2020/02/18' 
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("data_admissao", t.DataAdmissao.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("setor", t.Setor);
                query.Parameters.AddWithValue("salario", t.Salario);
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

        public List<Funcionario> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionario t)
        {
            throw new NotImplementedException();
        }
    }
}
