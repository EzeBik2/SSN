using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models.DataAccess
{
    public class Canchas
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


        public static bool AgregarUnaCancha(Cancha canchaAAgregar)
        {
            try
            {
                ConectarDB();
                querystr = "INSERT into Canchas (nombre, barrio, calle, telefono) VALUES ('" + canchaAAgregar.nombre + "', '" + canchaAAgregar.barrio + "', '" + canchaAAgregar.calle + "', '" + canchaAAgregar.telefono + "' )";
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
        public static bool ModificarUnaCancha(Cancha canchaAmodificar)
        {
            try
            {
                ConectarDB();
 
                querystr = "UPDATE Canchas SET nombre = '" + canchaAmodificar.nombre + "', barrio = '" + canchaAmodificar.barrio + "', calle = '" + canchaAmodificar.calle + "', telefono = '" + canchaAmodificar.telefono + "' WHERE id = '" + canchaAmodificar.id + "'";
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
        public static Cancha TraerUnaCancha(Cancha unaCancha)
        {
            Cancha unaCancha2 = new Cancha();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM Canchas";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"].ToString()) == unaCancha.id)
                    {
                        unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                        unaCancha2.nombre = dr["Nombre"].ToString();
                        unaCancha2.barrio = dr["Barrio"].ToString();
                        unaCancha2.calle = dr["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        conn.Close();
                        return unaCancha2;
                    }
                    if (dr["Nombre"].ToString() == unaCancha.nombre)
                    {
                        unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                        unaCancha2.nombre = dr["Nombre"].ToString();
                        unaCancha2.barrio = dr["Barrio"].ToString();
                        unaCancha2.calle = dr["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        conn.Close();
                        return unaCancha2;
                    }
                }

                conn.Close();
                return unaCancha2;
            }

            catch (Exception e)
            {
                conn.Close();
                return unaCancha2;
            }
        }
        public static List<Cancha> TraerCanchas(Cancha unaCancha)
        {
            List<Cancha> ListadeCanchas = new List<Cancha>();
            try
            {
                ConectarDB();

                querystr = "SELECT* FROM Canchas";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cancha unaCancha2 = new Cancha();
                    unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                    unaCancha2.nombre = dr["Nombre"].ToString();
                    unaCancha2.barrio = dr["Barrio"].ToString();
                    unaCancha2.calle = dr["Calle"].ToString();
                    unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                    if (unaCancha2.nombre == unaCancha.nombre)
                    {
                        ListadeCanchas.Add(unaCancha2);
                    }
                    else
                    {
                        if (unaCancha2.id == unaCancha.id)
                        {
                            ListadeCanchas.Add(unaCancha2);
                        }
                        else
                        {
                            if (unaCancha2.barrio == unaCancha.barrio)
                            {
                                ListadeCanchas.Add(unaCancha2);
                            }
                        }
                    }
                    if (unaCancha.id == 0 && unaCancha.nombre==null)
                    {
                        ListadeCanchas.Add(unaCancha2);
                    }
                }
                conn.Close();
                return ListadeCanchas;
            }

            catch (Exception e)
            {
                conn.Close();
                return ListadeCanchas;
            }
        }
        public static bool EliminarUnaCancha(int idCancha)
        {
            try
            {
                ConectarDB();

                querystr = "DELETE FROM Canchas WHERE id = '" + idCancha.ToString() + "'";
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

    }
}