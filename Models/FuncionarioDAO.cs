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
            throw new NotImplementedException();
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
