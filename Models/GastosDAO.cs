using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Sismeio.Interfaces;
using Sismeio.Base;
using MySql.Data.MySqlClient;


namespace Sismeio.Models
{
    class GastosDAO : IDAO<Gasto>
    {
        private static Conexao conn;

        public GastosDAO()
        {
            conn = new Conexao();
        }

        public void Delet(Gasto t)
        {
            throw new NotImplementedException();
        }

        public Gasto GetById(int codigo)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM gastos WHERE cod_gas = @codigo";

                query.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = query.ExecuteReader();

                var gasto = new Gasto();

                while (reader.Read())
                {


                    //(DateTime)dtPickerDataGasto.SelectedDate
                    gasto.Codigo = reader.GetInt32("cod_gas");
                    gasto.Valor = reader.GetDouble("valor_gas");
                    gasto.Data = reader.GetDateTime("data_gas");
                    gasto.Descricao = reader.GetString("descricao");
                    gasto.Caixa = reader.GetInt32("cod_cai_fk");



                    
                }

              
                
                
                return gasto;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Gasto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO gastos (valor_gas, data_gas, descricao, cod_cai_fk)" +
                    "VALUES(@valor, @data, @descricao, @caixa)";

                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@caixa", t.Caixa);

                var result = query.ExecuteNonQuery();

            } catch (Exception e)
            {
                throw e;

            } finally
            {
                conn.Close();
            }

        }
        
        public List<Gasto> List()
        {
            try
            {
                List<Gasto> list = new List<Gasto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM gastos";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Gasto()
                    {
                        //(DateTime)dtPickerDataGasto.SelectedDate
                        Codigo = reader.GetInt32("cod_gas"),
                        Valor = reader.GetDouble("valor_gas"),
                        Data = reader.GetDateTime("data_gas"),
                        Descricao = reader.GetString("descricao"),
                        Caixa = reader.GetInt32("cod_cai_fk")



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
        

        public void Update(Gasto t)
        {
            throw new NotImplementedException();
        }

        


    }
}
