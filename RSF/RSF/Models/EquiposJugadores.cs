using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class EquiposJugadores
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=|DataDirectory|\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "Agregar";
                
                OleDbParameter estado = new OleDbParameter("Estado", A.estado);
                OleDbParameter equipo = new OleDbParameter("Idequipo", A.idEquipo);
                OleDbParameter jugador = new OleDbParameter("Idjugador", A.idJugador);


                Consulta.Parameters.Add(estado);
                Consulta.Parameters.Add(equipo);
                Consulta.Parameters.Add(jugador);


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
        public static bool CambiarEstado(EquipoJugador A)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "CambiarEstado";

                OleDbParameter id = new OleDbParameter("id", A.id);
                OleDbParameter estado = new OleDbParameter("estado", A.estado);

                Consulta.Parameters.Add(estado);
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
        public static List<int> TraerJugadores(EquipoJugador A)
        {
            List<int> JugadoresdeEquipo = new List<int>();

            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerJugadoresDeEquipos";

                OleDbDataReader dr = Consulta.ExecuteReader();
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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerEquiposDeJugador";

                OleDbDataReader dr = Consulta.ExecuteReader();
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
        public static bool EliminarEquipo(int A)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "EliminarEquipos";

                OleDbParameter idequipo = new OleDbParameter("idequipo", A);

                Consulta.Parameters.Add(idequipo);

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
        public static bool Eliminar(int A)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "Eliminar";

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