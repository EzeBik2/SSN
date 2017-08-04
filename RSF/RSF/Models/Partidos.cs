using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models.DataAccess
{
    public class Partidos
    {
        static MySqlCommand cmd;

        static string querystr;

        static string Proveedor = @"Data Source=localhost; Database=DBRSF; User ID=root; Password='root'";

        static MySqlConnection conn = new MySqlConnection();

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

                querystr = "INSERT into Partidos (fecha, cantjug, idcancha) VALUES ('" + partidoAAgregar.Fecha + "', '" + partidoAAgregar.CantJug + "', '" + partidoAAgregar.IdCancha + "' )";
                cmd = new MySqlCommand(querystr, conn);

                int resultado = (int)cmd.ExecuteNonQuery();
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

                querystr = "SELECT* FROM Partidos";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (unPartido.id > 0)
                    {
                        if (Convert.ToInt32(dr["id"].ToString()) == unPartido.id)
                        {
                            unPartido2.id = Convert.ToInt32(dr["id"].ToString());
                            unPartido2.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                            unPartido2.CantJug = Convert.ToInt32(dr["cantjug"].ToString());
                            unPartido2.IdCancha = Convert.ToInt32(dr["idcancha"].ToString());
                            conn.Close();
                            return unPartido2;
                        }
                    }
                    if (Convert.ToInt32(dr["cantjug"].ToString()) == unPartido.CantJug && Convert.ToDateTime(dr["fecha"].ToString()) == unPartido.Fecha && Convert.ToInt32(dr["idcancha"].ToString()) == unPartido.IdCancha)
                    {
                        unPartido2.id = Convert.ToInt32(dr["id"].ToString());
                        unPartido2.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                        unPartido2.CantJug = Convert.ToInt32(dr["cantjug"].ToString());
                        unPartido2.IdCancha = Convert.ToInt32(dr["idcancha"].ToString());
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
        public static Partido TraerUnPartido2(Partido unPartido)
        {
            Partido unPartido2 = new Partido();

            try
            {
                ConectarDB();

                querystr = "SELECT* FROM Partidos WHERE id = '" + unPartido.id + "'";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToDateTime(dr["Fecha"].ToString()) == unPartido.Fecha && Convert.ToInt32(dr["Idcancha"].ToString()) == unPartido.IdCancha)
                    {
                        unPartido2.id = Convert.ToInt32(dr["Id"].ToString());
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

                querystr = "SELECT * FROM Partidos";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Partido unPartido2 = new Partido();
                    unPartido2.id = Convert.ToInt32(dr["id"].ToString());
                    unPartido2.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    unPartido2.CantJug = Convert.ToInt32(dr["cantjug"].ToString());
                    unPartido2.IdCancha = Convert.ToInt32(dr["idcancha"].ToString());
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