
using System;
using System.Linq   ;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Sismeio.Base
{
    class Conexao
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "";

        private static string dbname = "bd_equipe_snow";

     


        private static MySqlConnection connection;

        private static MySqlCommand command;


        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};user={user};database={dbname};port={port}; password={password}; ");
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }



        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception)
            {
                throw;
            }



        }

        public void Close()
        {
            connection.Close();
        }
    }
}

