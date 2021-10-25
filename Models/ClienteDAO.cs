using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using Sismeio.Base; 

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
            throw new NotImplementedException();
        }

        public Cliente GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente t)
        {
            try
            {
                var query = conec.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli, cpf_cli, rg_cli, data_nasc_cli, sexo_cli, telefone_cli, situacao_cli, historico_cli) VALUES (@NOME, @CPF, @RG, @data_nasc, @sexo, @telefone, @situacao, @historico)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@data_nasc", t.DataNascimento); //'18/02/2020 -> '2020/02/18'
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@situacao", t.Situacao);
                query.Parameters.AddWithValue("@historico", t.Historico);

                var result = query.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }finally
            {
                conec.Close();
            }
        }

        public List<Cliente> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
