using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace RSF.Models.DataAccess
{
    public class EquiposJugadores
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


        public static bool Agregar(EquipoJugador A)
        {
            try
            {
                ConectarDB();

                querystr = "INSERT into EquiposJugadores (estado, idEquipo, idJugador) VALUES ('" + A.estado + "', '" + A.idEquipo + "', '" + A.idJugador + "' )";
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

                querystr = "UPDATE Equiposjugadores SET estado = '" + A.estado + "' WHERE id = '" + A.id + "'";
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
        public static List<int> TraerJugadores(EquipoJugador A)
        {
            List<int> JugadoresdeEquipo = new List<int>();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM EquiposJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Idequipo"].ToString()) == A.idEquipo)
                    {
                        JugadoresdeEquipo.Add(Convert.ToInt32(dr["Idjugador"].ToString()));
                    }
                }
                
                conn.Close();
                return JugadoresdeEquipo;
            }

            catch (Exception e)
            {
                conn.Close();
                return JugadoresdeEquipo;
            }
        }
        public static List<int> TraerEquipos(EquipoJugador A)
        {
            List<int> EquiposDeJugador = new List<int>();

            try
            {
                ConectarDB();

                querystr = "SELECT * FROM EquiposJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Idjugador"].ToString()) == A.idJugador)
                    {
                        EquiposDeJugador.Add(Convert.ToInt32(dr["Idequipo"].ToString()));
                    }
                }

                conn.Close();
                return EquiposDeJugador;
            }

            catch (Exception e)
            {
                conn.Close();
                return EquiposDeJugador;
            }
        }
        public static EquipoJugador Traer(EquipoJugador X)
        {
            EquipoJugador W = new EquipoJugador();
            try
            {
                ConectarDB();

                querystr = "SELECT * FROM EquiposJugadores";
                cmd = new MySqlCommand(querystr, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"].ToString()) == X.id)
                    {
                        W.id = X.id;
                        W.estado = dr["Estado"].ToString();
                        W.idEquipo = Convert.ToInt32(dr["Idequipo"].ToString());
                        W.idJugador = Convert.ToInt32(dr["Idjugador"].ToString());
                        conn.Close();
                        return W;
                    }
                    int A = Convert.ToInt32(dr["Idjugador"].ToString());
                    int B = Convert.ToInt32(dr["Idequipo"].ToString());
                    if (A == X.idJugador && B == X.idEquipo)
                    {
                        W.id = Convert.ToInt32(dr["Id"].ToString());
                        W.estado = dr["Estado"].ToString();
                        W.idEquipo = Convert.ToInt32(dr["Idequipo"].ToString());
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

                querystr = "DELETE FROM EquiposJugadores WHERE id = '" + A.ToString() + "'";
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