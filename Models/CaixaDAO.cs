using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Interfaces;
using MySql.Data.MySqlClient;
using Sismeio.Helpers;
using Sismeio.Base;

namespace Sismeio.Models
{
    class CaixaDAO : IDAO<Caixa>
    {
        private static Conexao conn;

        public CaixaDAO()
        {
            conn = new Conexao();
        }

        public void Delet(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM caixa WHERE cod_cai = @codigo";


                query.Parameters.AddWithValue("@codigo", t.Codigo);

                var result = query.ExecuteNonQuery();


                if (result == 0)
                    throw new Exception("Caixa não excluído,  Tente Novamente!!");

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

        public Caixa GetById(int codigo)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM caixa WHERE cod_cai = @codigo";

                query.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = query.ExecuteReader();
                //gabi
                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado");

                var caixa = new Caixa();

                while (reader.Read())
                {


                    //(DateTime)dtPickerDataGasto.SelectedDate
                    caixa.Codigo = reader.GetInt32("cod_cai");
                    caixa.Mes = reader.GetString("mes_cai");
                    caixa.SaldoAnt = reader.GetDouble("saldo_ant_cai");
                    caixa.SaldoFin = reader.GetDouble("saldo_final_cai");
                    caixa.Debitos = reader.GetDouble("debitos_cai");
                    caixa.Creditos = reader.GetDouble("creditos_cai");


                    //if (DAOHelper.IsNull(reader, "cod_cai_fk"))
                       // gasto.Caixa = reader.GetInt32("cod_cai_fk");



                }




                return caixa;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO caixa (mes_cai, saldo_ant_cai, saldo_final_cai, debitos_cai, creditos_cai)" +
                    "VALUES(@mes, @saldoa, @saldof, @debitos, @creditos)";

                query.Parameters.AddWithValue("@mes", t.Mes);
                query.Parameters.AddWithValue("@saldoa", t.SaldoAnt);
                query.Parameters.AddWithValue("@saldof", t.SaldoFin);
                query.Parameters.AddWithValue("@debitos", t.Debitos);
                query.Parameters.AddWithValue("@creditos", t.Creditos);

                var result = query.ExecuteNonQuery();


                if (result == 0)
                    throw new Exception("O Registro não foi inserido, Tente Novamente!!");

                

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

        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    

                    list.Add(new Caixa()
                    {

                        Codigo = reader.GetInt32("cod_cai"),
                        Mes = DAOHelper.GetString(reader, "mes_cai"),
                        SaldoAnt = DAOHelper.GetDouble(reader, "saldo_ant_cai"),
                        SaldoFin = DAOHelper.GetDouble(reader, "saldo_final_cai"),
                        Debitos = DAOHelper.GetDouble(reader, "debitos_cai"),
                        Creditos = DAOHelper.GetDouble(reader, "creditos_cai")


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


        public void Update(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE caixa SET mes_cai = @mes, saldo_ant_cai = @saldoa, saldo_ant_cai = @saldof, debitos_cai = @debitos, creditos_cai = @creditos" +
                    "WHERE cod_cai =@codigo";

                query.Parameters.AddWithValue("@codigo", t.Codigo);

                query.Parameters.AddWithValue("@mes", t.Mes);
                query.Parameters.AddWithValue("@saldoa", t.SaldoAnt);
                query.Parameters.AddWithValue("@saldof", t.SaldoFin);
                query.Parameters.AddWithValue("@debitos", t.Debitos);
                query.Parameters.AddWithValue("@creditos", t.Creditos);

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
