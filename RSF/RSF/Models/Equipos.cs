using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models.DataAccess
{
    public class Equipos
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

        public static bool AgregarUnEquipo(Equipo equipoAAgregar)
        {
            try
            {
                ConectarDB();

                querystr = "INSERT into Equipos (nombre, cantjug, calificacion, cantvotos) VALUES ('" + equipoAAgregar.nombre + "', '" + equipoAAgregar.cantjug + "', '" + 0 + "', '" + 0 + "' )";
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
        public static bool ModificarUnEquipo(Equipo equipoAModificar)
        {
            try
            {
                ConectarDB();

                querystr = "UPDATE Equipos SET nombre = '" + equipoAModificar.nombre + "', barrio = '" + equipoAModificar.cantjug + "', calle = '" + equipoAModificar.calificacion + "', telefono = '" + equipoAModificar.cantvotos + "' WHERE id = '" + equipoAModificar.id + "'";
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
        public static Equipo TraerUnEquipo(Equipo unEquipo)
        {
            Equipo unEquipo2 = new Equipo();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM Equipos";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (unEquipo.id > 0)
                    {
                        if (Convert.ToInt32(dr["Id"].ToString()) == unEquipo.id)
                        {
                            unEquipo2.id = Convert.ToInt32(dr["Id"].ToString());
                            unEquipo2.nombre = dr["Nombre"].ToString();
                            unEquipo2.cantjug = Convert.ToInt32(dr["Cantjug"].ToString());
                            unEquipo2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                            unEquipo2.cantvotos = Convert.ToInt32(dr["Cantvotos"].ToString());
                            conn.Close();
                            return unEquipo2;
                        }
                    }
                    else
                    {
                        if (dr["Nombre"].ToString() == unEquipo.nombre)
                        {
                            unEquipo2.id = Convert.ToInt32(dr["Id"].ToString());
                            unEquipo2.nombre = dr["Nombre"].ToString();
                            unEquipo2.cantjug = Convert.ToInt32(dr["Cantjug"].ToString());
                            unEquipo2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                            unEquipo2.cantvotos = Convert.ToInt32(dr["Cantvotos"].ToString());
                            conn.Close();
                            return unEquipo2;
                        }
                    }                    
                }

                conn.Close();
                return unEquipo2;
            }

            catch (Exception e)
            {
                conn.Close();
                return unEquipo2;
            }
        }
        public static List<Equipo> TraerEquipos(Equipo unEquipo)
        {
            List<Equipo> ListadeEquipos = new List<Equipo>();
            try
            {
                ConectarDB();

                querystr = "SELECT * FROM Equipos";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Equipo unEquipo2 = new Equipo();
                    unEquipo2.id = Convert.ToInt32(dr["Id"].ToString());
                    unEquipo2.nombre = dr["Nombre"].ToString();
                    unEquipo2.cantjug = Convert.ToInt32(dr["Cantjug"].ToString());
                    unEquipo2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                    unEquipo2.cantvotos = Convert.ToInt32(dr["Cantvotos"].ToString());
                    if (unEquipo2.nombre == unEquipo.nombre)
                    {
                        ListadeEquipos.Add(unEquipo2);
                    }
                    if (unEquipo2.id == unEquipo.id)
                    {
                        ListadeEquipos.Add(unEquipo2);
                    }
                }
                conn.Close();
                return ListadeEquipos;
            }

            catch (Exception e)
            {
                conn.Close();
                return ListadeEquipos;
            }
        }
        public static bool EliminarUnEquipo(int A)
        {
            try
            {
                ConectarDB();

                querystr = "DELETE FROM Equipos WHERE id = '" + A + "'";
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