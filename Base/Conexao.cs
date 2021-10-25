using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sismeio.Base
{
    class Conexao
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "";

        private static string dbname = "bd_equipe_snow";

        private static string sslmode = "none";




        private static MySqlConnection connection;

        private static MySqlCommand command;


        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};user={user};database={dbname};port={port}; password={password}; sslmode={sslmode}");
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
