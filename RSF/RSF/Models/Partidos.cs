using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class Partidos
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=|DataDirectory|\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

        private static void ConectarDB()
        {
            conn.ConnectionString = Proveedor;
            conn.Open();
        }
        
        public static bool AgregarUnPartido(Partido partidoAAgregar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarPartido";
                
                OleDbParameter cantjug = new OleDbParameter("Cantjug", OleDbType.VarChar, 88);
                cantjug.Value = partidoAAgregar.CantJug;
                OleDbParameter fecha = new OleDbParameter("Fecha", OleDbType.VarChar, 88);
                fecha.Value = partidoAAgregar.Fecha;
                OleDbParameter idcancha = new OleDbParameter("Idcancha", OleDbType.VarChar, 88);
                idcancha.Value = partidoAAgregar.IdCancha;
                
                Consulta.Parameters.Add(cantjug);
                Consulta.Parameters.Add(fecha);
                Consulta.Parameters.Add(idcancha);


                int resultado = (int)Consulta.ExecuteNonQuery();
                bool funciono = false;
                if (resultado == 1)
                {
                    funciono = true;
                }

                conn.Close();
                return funciono;
            }


            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }
        public static Partido TraerUnPartido(Partido unPartido)
        {
            Partido unPartido2 = new Partido();

            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerPartidos";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (unPartido.id > 0)
                    {
                        if (Convert.ToInt32(dr["Id"].ToString()) == unPartido.id)
                        {
                            unPartido2.id = Convert.ToInt32(dr["Id"].ToString());
                            unPartido2.CantJug = Convert.ToInt32(dr["Cantjug"].ToString());
                            unPartido2.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                            unPartido2.IdCancha = Convert.ToInt32(dr["Idcancha"].ToString());
                            conn.Close();
                            return unPartido2;
                        }
                    }
                    if (Convert.ToInt32(dr["Cantjug"].ToString()) == unPartido.CantJug && Convert.ToDateTime(dr["Fecha"].ToString()) == unPartido.Fecha && Convert.ToInt32(dr["Idcancha"].ToString()) == unPartido.IdCancha)
                    {
                        unPartido2.id = Convert.ToInt32(dr["Id"].ToString());
                        unPartido2.CantJug = Convert.ToInt32(dr["Cantjug"].ToString());
                        unPartido2.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                        unPartido2.IdCancha = Convert.ToInt32(dr["Idcancha"].ToString());
                        conn.Close();
                        return unPartido2;
                    }
                }

                conn.Close();
                return unPartido2;
            }

            catch (Exception e)
            {
                conn.Close();
                return unPartido2;
            }
        }
        public static List<Partido> TraerPartidos()
        {
            List<Partido> ListadePartidos = new List<Partido>();
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerPartidos";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    Partido unPartido2 = new Partido();
                    unPartido2.id = Convert.ToInt32(dr["Id"].ToString());
                    unPartido2.CantJug = Convert.ToInt32(dr["Cantjug"].ToString());
                    unPartido2.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    unPartido2.IdCancha = Convert.ToInt32(dr["Idcancha"].ToString());   
                    ListadePartidos.Add(unPartido2);
                }
                conn.Close();
                return ListadePartidos;
            }

            catch (Exception e)
            {
                conn.Close();
                return ListadePartidos;
            }
        }


    }
}