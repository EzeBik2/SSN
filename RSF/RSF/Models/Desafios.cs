using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models
{
    public class Desafios
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

        public static Desafio CrearDesafio(Desafio desafioAAgregar)
        {
            Desafio desafio2 = new Desafio();

            try
            {
                ConectarDB();

                querystr = "INSERT into Desafios (IdCancha, Fecha, IdEquipo1, IdEquipo2, CantidadDeJugadores) VALUES ('" + desafioAAgregar.idcancha + "', '" + desafioAAgregar.fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + desafioAAgregar.idequipo1 + "', '" + desafioAAgregar.idequipo2 + "', '" + desafioAAgregar.cantidaddejugadores + "' )";
                cmd = new MySqlCommand(querystr, conn);

                int resultado = (int)cmd.ExecuteNonQuery();
                bool funciono = false;
                if (resultado == 1)
                {
                    funciono = true;
                }

                conn.Close();
               
                     ConectarDB();

                    querystr = "SELECT * FROM Desafios";
                    cmd = new MySqlCommand(querystr, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (Convert.ToDateTime(dr["Fecha"].ToString()) == desafioAAgregar.fecha && Convert.ToInt32(dr["IdCancha"].ToString()) == desafioAAgregar.idcancha)
                        {
                            desafio2.Id = Convert.ToInt32(dr["Id"].ToString());
                            desafio2.idcancha = Convert.ToInt32(dr["IdCancha"].ToString());
                            desafio2.fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                            desafio2.cantidaddejugadores = Convert.ToInt32(dr["CantidadDeJugadores"].ToString());
                            desafio2.idequipo1 = Convert.ToInt32(dr["IdEquipo1"].ToString());
                            desafio2.idequipo2 = Convert.ToInt32(dr["IdEquipo2"].ToString());
                            conn.Close();
                        }
                    }

                    conn.Close();
                    return desafio2;
            }

            catch (Exception e)
            {
                conn.Close();
                return desafio2;
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
                    if (unEquipo2.nombre.Contains(unEquipo.nombre))
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