using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Sismeio
{
    class Conexao
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "root";

        private static string dbname = "bd_equipe_snow";

        private static MySqlConnection conection;

        private static MySqlCommand comand;


        public Conexao()
        {
            try
            {
                conection = new MySqlConnection($"server={host};user={user};database={dbname};port={port}; password={password}");
                conection.Open();
            }
            catch(Exception)
            {
                throw;
            }



        }




    }
}
