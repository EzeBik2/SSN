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


        public static bool GuardarEquipo(Equipo equipoAGuardar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "GuardarEquipo";

                OleDbParameter nombre = new OleDbParameter("nombre", equipoAGuardar.nombre);
                OleDbParameter cantjug = new OleDbParameter("cantjug", equipoAGuardar.cantjug);

  
                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(cantjug);

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

        public static List<Equipo> existeEquipo(Equipo unEquipo)
        {
            List<Equipo> ListadeEquipos = new List<Equipo>();
            
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TodosEquipos";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (unEquipo.nombre != null)
                    {
                        if (dr["Nombre"].ToString().IndexOf(unEquipo.nombre) + 1 > 0)
                        {
                            Equipo unCan = new Equipo();
                            unCan.nombre = dr["Nombre"].ToString();
                            unCan.id = dr["Id"].ToString();
                            unCan.cantjug = dr["CantJug"].ToString();
                            ListadeEquipos.Add(unCan);
                        }
                    }
                    else
                    {
                        if (dr["Id"].ToString().IndexOf(unEquipo.id) + 1 > 0)
                        {
                            Equipo unCan = new Equipo();
                            unCan.nombre = dr["Nombre"].ToString();
                            unCan.id = dr["Id"].ToString();
                            unCan.cantjug = dr["CantJug"].ToString();
                            ListadeEquipos.Add(unCan);
                        }
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

    }
}