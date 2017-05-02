using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class Jugadores
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=|DataDirectory|\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarJugador";

                OleDbParameter nombre = new OleDbParameter("nombre", jugadorAAgregar.nombre);
                OleDbParameter apellido = new OleDbParameter("apellido", jugadorAAgregar.apellido);
                OleDbParameter foto = new OleDbParameter("foto", "");
                OleDbParameter edad = new OleDbParameter("edad", Convert.ToInt32(jugadorAAgregar.edad));
                OleDbParameter telefono = new OleDbParameter("telefono", Convert.ToInt32(jugadorAAgregar.telefono));
                OleDbParameter calificacion = new OleDbParameter("calificacion", 0);
                OleDbParameter cantidaddevotos = new OleDbParameter("cantidaddevotos", 0);
                OleDbParameter email = new OleDbParameter("email", jugadorAAgregar.email);
                OleDbParameter contraseña = new OleDbParameter("contraseña", jugadorAAgregar.contraseña);

                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(apellido);
                Consulta.Parameters.Add(foto);
                Consulta.Parameters.Add(edad);
                Consulta.Parameters.Add(telefono);
                Consulta.Parameters.Add(calificacion);
                Consulta.Parameters.Add(cantidaddevotos);
                Consulta.Parameters.Add(email);
                Consulta.Parameters.Add(contraseña);

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
        public static bool ModificarUnJugador(Jugador jugadorAModificar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "ModificarJugador";

                OleDbParameter nombre = new OleDbParameter("nombre", jugadorAModificar.nombre);
                OleDbParameter apellido = new OleDbParameter("apellido", jugadorAModificar.apellido);
                OleDbParameter foto = new OleDbParameter("foto", jugadorAModificar.foto);
                OleDbParameter edad = new OleDbParameter("edad", Convert.ToInt32(jugadorAModificar.edad));
                OleDbParameter telefono = new OleDbParameter("telefono", Convert.ToInt32(jugadorAModificar.telefono));
                OleDbParameter calificacion = new OleDbParameter("calificacion", jugadorAModificar.calificacion);
                OleDbParameter cantidaddevotos = new OleDbParameter("cantvotos", jugadorAModificar.cantidaddevotos);
                OleDbParameter email = new OleDbParameter("email", jugadorAModificar.email);
                OleDbParameter contraseña = new OleDbParameter("contraseña", jugadorAModificar.contraseña);
                OleDbParameter id = new OleDbParameter("id", jugadorAModificar.id);

                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(apellido);
                Consulta.Parameters.Add(foto);
                Consulta.Parameters.Add(edad);
                Consulta.Parameters.Add(telefono);
                Consulta.Parameters.Add(calificacion);
                Consulta.Parameters.Add(cantidaddevotos);
                Consulta.Parameters.Add(email);
                Consulta.Parameters.Add(contraseña);
                Consulta.Parameters.Add(id);

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
        public static Jugador TraerUnJugador(Jugador unJugador)
        {
            Jugador unJugador2 = new Jugador();

            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerJugadores";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"].ToString()) == unJugador.id)
                    {
                        unJugador2.id = Convert.ToInt32(dr["Id"].ToString());
                        unJugador2.nombre = dr["Nombre"].ToString();
                        unJugador2.apellido = dr["Apellido"].ToString();
                        unJugador2.foto = dr["Foto"].ToString();
                        unJugador2.edad = Convert.ToInt32(dr["Edad"].ToString());
                        unJugador2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        unJugador2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                        unJugador2.cantidaddevotos = Convert.ToInt32(dr["Cantidaddevotos"].ToString());
                        unJugador2.email = dr["Email"].ToString();
                        unJugador2.contraseña = dr["Contraseña"].ToString();
                        conn.Close();
                        return unJugador2;
                    }
                    if (dr["Email"].ToString() == unJugador.email && dr["Contraseña"].ToString() == unJugador.contraseña)
                    {
                        unJugador2.id = Convert.ToInt32(dr["Id"].ToString());
                        unJugador2.nombre = dr["Nombre"].ToString();
                        unJugador2.apellido = dr["Apellido"].ToString();
                        unJugador2.foto = dr["Foto"].ToString();
                        unJugador2.edad = Convert.ToInt32(dr["Edad"].ToString());
                        unJugador2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        unJugador2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                        unJugador2.cantidaddevotos = Convert.ToInt32(dr["CantidaddeVotos"].ToString());
                        unJugador2.email = dr["Email"].ToString();
                        unJugador2.contraseña = dr["Contraseña"].ToString();
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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerJugadores";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    Jugador unJugador2 = new Jugador();
                    unJugador2.id = Convert.ToInt32(dr["Id"].ToString());
                    unJugador2.nombre = dr["Nombre"].ToString();
                    unJugador2.apellido = dr["Apellido"].ToString();
                    unJugador2.foto = dr["Foto"].ToString();
                    unJugador2.edad = Convert.ToInt32(dr["Edad"].ToString());
                    unJugador2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                    unJugador2.calificacion = Convert.ToInt32(dr["Calificacion"].ToString());
                    unJugador2.cantidaddevotos = Convert.ToInt32(dr["CantidaddeVotos"].ToString());
                    unJugador2.email = dr["Email"].ToString();
                    unJugador2.contraseña = dr["Contraseña"].ToString();
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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "EliminarJugador";

                OleDbParameter id = new OleDbParameter("id", A);

                Consulta.Parameters.Add(id);

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

    }
}