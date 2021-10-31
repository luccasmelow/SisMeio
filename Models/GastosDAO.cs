using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Sismeio.Interfaces;
using Sismeio.Base;
using MySql.Data.MySqlClient;
using Sismeio.Helpers;


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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM gastos WHERE cod_gas = @codigo";

               
                query.Parameters.AddWithValue("@codigo", t.Codigo);

                var result = query.ExecuteNonQuery();


                if (result == 0)
                    throw new Exception("O Registro não excluído,  Tente Novamente!!");

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

        public Gasto GetById(int codigo)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM gastos WHERE cod_gas = @codigo";

                query.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado");

                var gasto = new Gasto();

                while (reader.Read())
                {


                    //(DateTime)dtPickerDataGasto.SelectedDate
                    gasto.Codigo = reader.GetInt32("cod_gas");
                    gasto.Valor = reader.GetDouble("valor_gas");
                    if (DAOHelper.IsNull(reader, "data_gas"))
                        gasto.Data = reader.GetDateTime("data_gas");
                    gasto.Descricao = reader.GetString("descricao");


                    if (DAOHelper.IsNull(reader, "cod_cai_fk"))
                        gasto.Caixa = new Caixa()
                        {
                            Codigo = reader.GetInt32("cod_cai"),
                            Mes = reader.GetString("mes_cai")
                        };



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
                query.Parameters.AddWithValue("@data", t.Data?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@caixa", t.Caixa.Codigo);

                var result = query.ExecuteNonQuery();


                if (result==0)
                    throw new Exception("O Registro não foi inserido, Tente Novamente!!");

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
                query.CommandText = "SELECT * FROM gastos LEFT JOIN caixa ON cod_cai = cod_cai_fk ";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Gasto()
                    { 
                    
                        //(DateTime)dtPickerDataGasto.SelectedDate
                        Codigo = reader.GetInt32("cod_gas"),
                        Valor = DAOHelper.GetDouble(reader, "valor_gas"),
                        Data = DAOHelper.GetDateTime (reader,"data_gas"),
                        Descricao = DAOHelper.GetString(reader,"descricao"),
                       // Caixa = DAOHelper.IsNull(reader, "cod_cai_fk") ? null : new Caixa() { Codigo = reader.GetInt32("cod_caixa")}

                        
                        Caixa = DAOHelper.IsNull(reader, "cod_cai_fk") ? null : new Caixa()
                        {
                            Codigo = reader.GetInt32("cod_cai"),
                            Mes = reader.GetString("mes_cai"),
                            SaldoAnt = reader.GetDouble("saldo_ant_cai"),
                            SaldoFin = reader.GetDouble("saldo_final_cai"),
                            Debitos = reader.GetDouble("debitos_cai"),
                            Creditos = reader.GetDouble("creditos_cai")
                        }
                        
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
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE gastos SET valor_gas = @valor, data_gas = @data, descricao = @descricao, cod_cai_fk = @caixa" +
                    "WHERE cod_gas =@codigo";

                query.Parameters.AddWithValue("@codigo", t.Codigo);

                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@data", t.Data?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@caixa", t.Caixa.Codigo);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização não Realizada, Tente Novamente!!");

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


                    