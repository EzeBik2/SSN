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
                OleDbParameter idjug1 = new OleDbParameter("idjug1", equipoAGuardar.idjug1);
                OleDbParameter idjug2 = new OleDbParameter("idjug2", equipoAGuardar.idjug2);
                OleDbParameter idjug3 = new OleDbParameter("idjug3", equipoAGuardar.idjug3);
                OleDbParameter idjug4 = new OleDbParameter("idjug4", equipoAGuardar.idjug4);
                OleDbParameter idjug5 = new OleDbParameter("idjug5", equipoAGuardar.idjug5);
                OleDbParameter idjug6 = new OleDbParameter("idjug6", equipoAGuardar.idjug6);
                OleDbParameter idjug7 = new OleDbParameter("idjug7", equipoAGuardar.idjug7);
                OleDbParameter idjug8 = new OleDbParameter("idjug8", equipoAGuardar.idjug8);
                OleDbParameter idjug9 = new OleDbParameter("idjug9", equipoAGuardar.idjug9);
                OleDbParameter idjug10 = new OleDbParameter("idjug10", equipoAGuardar.idjug10);
                OleDbParameter idjug11 = new OleDbParameter("idjug11", equipoAGuardar.idjug11);

  
                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(cantjug);
                Consulta.Parameters.Add(idjug1);
                Consulta.Parameters.Add(idjug2);
                Consulta.Parameters.Add(idjug3);
                Consulta.Parameters.Add(idjug4);
                Consulta.Parameters.Add(idjug5);
                Consulta.Parameters.Add(idjug6);
                Consulta.Parameters.Add(idjug7);
                Consulta.Parameters.Add(idjug8);
                Consulta.Parameters.Add(idjug9);
                Consulta.Parameters.Add(idjug10);
                Consulta.Parameters.Add(idjug11);


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
                            unCan.idjug1 = dr["IdJug1"].ToString();
                            unCan.idjug2 = dr["IdJug2"].ToString();
                            unCan.idjug3 = dr["IdJug3"].ToString();
                            unCan.idjug4 = dr["IdJug4"].ToString();
                            unCan.idjug5 = dr["IdJug5"].ToString();
                            unCan.idjug6 = dr["IdJug6"].ToString();
                            unCan.idjug7 = dr["IdJug7"].ToString();
                            unCan.idjug8 = dr["IdJug8"].ToString();
                            unCan.idjug9 = dr["IdJug9"].ToString();
                            unCan.idjug10 = dr["IdJug10"].ToString();
                            unCan.idjug11 = dr["IdJug11"].ToString();
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
                            unCan.idjug1 = dr["IdJug1"].ToString();
                            unCan.idjug2 = dr["IdJug2"].ToString();
                            unCan.idjug3 = dr["IdJug3"].ToString();
                            unCan.idjug4 = dr["IdJug4"].ToString();
                            unCan.idjug5 = dr["IdJug5"].ToString();
                            unCan.idjug6 = dr["IdJug6"].ToString();
                            unCan.idjug7 = dr["IdJug7"].ToString();
                            unCan.idjug8 = dr["IdJug8"].ToString();
                            unCan.idjug9 = dr["IdJug9"].ToString();
                            unCan.idjug10 = dr["IdJug10"].ToString();
                            unCan.idjug11 = dr["IdJug11"].ToString();
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