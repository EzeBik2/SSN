using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RSF.Models.DataAccess
{
    public class PartidosJugadores
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


        public static bool Agregar(PartidoJugador A)
        {
            try
            {
                ConectarDB();

                querystr = "INSERT into PartidosJugadores (estado, idPartido, idJugador) VALUES ('En formacion', '" + A.idPartido + "', '" + A.idJugador + "' )";
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
        public static bool CambiarEstado(EquipoJugador A)
        {
            try
            {
                ConectarDB();

                querystr = "UPDATE Partidosjugadores SET estado = '" + A.estado + "' WHERE id = '" + A.id + "'";
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
        public static List<int> TraerJugadores(PartidoJugador A)
        {
            List<int> JugadoresdePartido= new List<int>();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM PartidosJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Idpartido"].ToString()) == A.idPartido)
                    {
                        JugadoresdePartido.Add(Convert.ToInt32(dr["Idjugador"].ToString()));
                    }
                }
                
                conn.Close();
                return JugadoresdePartido;
            }

            catch (Exception e)
            {
                conn.Close();
                return JugadoresdePartido;
            }
        }
        public static List<int> TraerPartidos(PartidoJugador A)
        {
            List<int> PartidosDeJugador = new List<int>();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM PartidosJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["idjugador"].ToString()) == A.idJugador)
                    {
                        PartidosDeJugador.Add(Convert.ToInt32(dr["idpartido"].ToString()));
                    }
                }

                conn.Close();
                return PartidosDeJugador;
            }

            catch (Exception e)
            {
                conn.Close();
                return PartidosDeJugador;
            }
        }
        public static PartidoJugador Traer(PartidoJugador X)
        {
            PartidoJugador W = new PartidoJugador();
            try
            {
                ConectarDB();

                querystr = "SELECT * FROM PartidosJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"].ToString()) == X.id)
                    {
                        W.id = X.id;
                        W.estado = dr["Estado"].ToString();
                        W.idPartido = Convert.ToInt32(dr["Idpartido"].ToString());
                        W.idJugador = Convert.ToInt32(dr["Idjugador"].ToString());
                        conn.Close();
                        return W;
                    }
                    if (Convert.ToInt32(dr["Idjugador"].ToString()) == X.idJugador && Convert.ToInt32(dr["Idpartido"].ToString()) == X.idPartido)
                    {
                        W.id = Convert.ToInt32(dr["Id"].ToString());
                        W.estado = dr["Estado"].ToString();
                        W.idPartido = Convert.ToInt32(dr["Idpartido"].ToString());
                        W.idJugador = Convert.ToInt32(dr["Idjugador"].ToString());
                        conn.Close();
                        return W;
                    }
                }

                conn.Close();
                return W;
            }

            catch (Exception e)
            {
                conn.Close();
                return W;
            }
        }
        public static bool EliminarEquipo(int A)
        {
            try
            {
                ConectarDB();

                querystr = "DELETE FROM Equipos WHERE id = '" + A.ToString() + "'";
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
        public static bool Eliminar(int A)
        {
            try
            {
                ConectarDB();

                querystr = "DELETE FROM PartidosJugadores WHERE id = '" + A.ToString() + "'";
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