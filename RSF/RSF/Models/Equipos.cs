using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class Equipos
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=|DataDirectory|\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarEquipo";

                OleDbParameter nombre = new OleDbParameter("nombre", equipoAAgregar.nombre);
                OleDbParameter cantjug = new OleDbParameter("cantjug", equipoAAgregar.cantjug);
                OleDbParameter calificacion = new OleDbParameter("calificacion", 0);
                OleDbParameter cantidaddevotos = new OleDbParameter("cantvotos", 0);

                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(cantjug);
                Consulta.Parameters.Add(calificacion);
                Consulta.Parameters.Add(cantidaddevotos);


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
        public static bool ModificarUnEquipo(Equipo equipoAModificar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "ModificarEquipo";

                OleDbParameter nombre = new OleDbParameter("nombre", equipoAModificar.nombre);
                OleDbParameter cantjug = new OleDbParameter("cantjug", equipoAModificar.cantjug);
                OleDbParameter calificacion = new OleDbParameter("calificacion", 0);
                OleDbParameter cantidaddevotos = new OleDbParameter("cantvotos", 0);

                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(cantjug);
                Consulta.Parameters.Add(calificacion);
                Consulta.Parameters.Add(cantidaddevotos);

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
        public static Equipo TraerUnEquipo(Equipo unEquipo)
        {
            Equipo unEquipo2 = new Equipo();

            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerEquipos";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerEquipos";

                OleDbDataReader dr = Consulta.ExecuteReader();
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

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "EliminarEquipo";

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