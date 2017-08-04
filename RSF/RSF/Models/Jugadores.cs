using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models.DataAccess
{
    public class Jugadores
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


        public static bool AgregarUnJugador(Jugador jugadorAAgregar)
        {
            try
            {
                ConectarDB();

                querystr = "INSERT into Jugadores (nombre, apellido, foto, edad, telefono, calificacion, cantidaddevotos, email, clave) VALUES ('" + jugadorAAgregar.nombre + "', '" + jugadorAAgregar.apellido + "', '" + jugadorAAgregar.foto + "', '" + jugadorAAgregar.edad + "', '" + jugadorAAgregar.telefono + "', '" + jugadorAAgregar.calificacion + "', '" + jugadorAAgregar.cantidaddevotos + "', '" + jugadorAAgregar.email + "', '" + jugadorAAgregar.contraseña + "' )";
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
        public static bool ModificarUnJugador(Jugador jugadorAModificar)
        {
            try
            {
                ConectarDB();

                querystr = "UPDATE Jugadores SET nombre = '" + jugadorAModificar.nombre + "', apellido = '" + jugadorAModificar.apellido + "', foto = '" + jugadorAModificar.foto + "', edad = '" + jugadorAModificar.edad + "', telefono = '" + jugadorAModificar.telefono + "', calificacion = '" + jugadorAModificar.calificacion + "', cantidaddevotos = '" + jugadorAModificar.cantidaddevotos + "', email = '" + jugadorAModificar.email + "', contraseña = '" + jugadorAModificar.contraseña + "' WHERE id = '" + jugadorAModificar.id + "'";
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
        public static Jugador TraerUnJugador(Jugador unJugador)
        {
            Jugador unJugador2 = new Jugador();

            try
            {
                ConectarDB();

                querystr = "SELECT* FROM Jugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {                  
                    if (dr["email"].ToString() == unJugador.email && dr["clave"].ToString() == unJugador.contraseña)
                    {
                        unJugador2.id = Convert.ToInt32(dr["id"].ToString());
                        unJugador2.nombre = dr["nombre"].ToString();
                        unJugador2.apellido = dr["apellido"].ToString();
                        unJugador2.foto = dr["foto"].ToString();
                        unJugador2.edad = Convert.ToInt32(dr["edad"].ToString());
                        unJugador2.telefono = Convert.ToInt32(dr["telefono"].ToString());
                        unJugador2.calificacion = Convert.ToInt32(dr["calificacion"].ToString());
                        unJugador2.cantidaddevotos = Convert.ToInt32(dr["cantidaddeVotos"].ToString());
                        unJugador2.email = dr["email"].ToString();
                        unJugador2.contraseña = dr["clave"].ToString();
                        conn.Close();
                        return unJugador2;
                    }
                }

                conn.Close();
                return unJugador2;
            }

            catch (Exception e)
            {
                conn.Close();
                return unJugador2;
            }
        }
        public static List<Jugador> TraerJugadores(Jugador unJugador)
        {
            List<Jugador> ListadeJugadores = new List<Jugador>();

            try
            {
                ConectarDB();

                querystr = "SELECT* FROM Jugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Jugador unJugador2 = new Jugador();
                    unJugador2.id = Convert.ToInt32(dr["id"].ToString());
                    unJugador2.nombre = dr["nombre"].ToString();
                    unJugador2.apellido = dr["apellido"].ToString();
                    unJugador2.foto = dr["foto"].ToString();
                    unJugador2.edad = Convert.ToInt32(dr["edad"].ToString());
                    unJugador2.telefono = Convert.ToInt32(dr["telefono"].ToString());
                    unJugador2.calificacion = Convert.ToInt32(dr["calificacion"].ToString());
                    unJugador2.cantidaddevotos = Convert.ToInt32(dr["cantidaddevotos"].ToString());
                    unJugador2.email = dr["email"].ToString();
                    unJugador2.contraseña = dr["clave"].ToString();
                    if (unJugador2.id == unJugador.id)
                    {
                        ListadeJugadores.Add(unJugador2);
                    }
                    else
                    {
                        if (unJugador2.nombre == unJugador.nombre)
                        {
                            ListadeJugadores.Add(unJugador2);
                        }
                    }                    
                }
                conn.Close();
                return ListadeJugadores;
            }

            catch (Exception e)
            {
                conn.Close();
                return ListadeJugadores;
            }
        }
        public static bool EliminarUnJugador(int A)
        {
            try
            {
                ConectarDB();

                querystr = "DELETE FROM Jugadores WHERE id = '" + A.ToString() + "'";
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