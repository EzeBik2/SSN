using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class Canchas
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=D:\Users\42498978\Desktop\RSF\RSF\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

        private static void ConectarDB()
        {
            conn.ConnectionString = Proveedor;
            conn.Open();
        }


        public static bool GuardarCancha(Cancha canchaAGuardar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "GuardarCancha";

                OleDbParameter nombreCancha = new OleDbParameter("nombre", canchaAGuardar.nombre);
                OleDbParameter telefonoCancha = new OleDbParameter("telefono", canchaAGuardar.Telefono);
                OleDbParameter barrioCancha = new OleDbParameter("barrio", canchaAGuardar.Barrio);
                OleDbParameter calleCancha = new OleDbParameter("calle", canchaAGuardar.Calle);


                Consulta.Parameters.Add(nombreCancha);
                Consulta.Parameters.Add(telefonoCancha);
                Consulta.Parameters.Add(barrioCancha);
                Consulta.Parameters.Add(calleCancha);


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

        public static List<Cancha> existeCancha(Cancha unCancha)
        {
            List<Cancha> ListadeCanchas = new List<Cancha>();
            
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TodasCanchas";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (unCancha.nombre != null)
                    {
                        if (unCancha.nombre == dr["Nombre"].ToString())
                        {
                            Cancha unCan = new Cancha();
                            unCan.nombre = dr["Nombre"].ToString();
                            unCan.id = dr["Id"].ToString();
                            unCan.Barrio = dr["Barrio"].ToString();
                            unCan.Calle = dr["Calle"].ToString();
                            unCan.Telefono = dr["Telefono"].ToString();
                            ListadeCanchas.Add(unCan);
                        }
                    }
                    else
                    {
                        if (unCancha.id != null)
                        {
                            if (unCancha.id == dr["Id"].ToString())
                            {
                                Cancha unCan = new Cancha();
                                unCan.nombre = dr["Nombre"].ToString();
                                unCan.id = dr["Id"].ToString();
                                unCan.Barrio = dr["Barrio"].ToString();
                                unCan.Calle = dr["Calle"].ToString();
                                unCan.Telefono = dr["Telefono"].ToString();
                                ListadeCanchas.Add(unCan);
                            }

                        }
                        else
                        {
                            if (unCancha.Barrio == dr["Barrio"].ToString())
                            {
                                Cancha unCan = new Cancha();
                                unCan.nombre = dr["Nombre"].ToString();
                                unCan.id = dr["Id"].ToString();
                                unCan.Barrio = dr["Barrio"].ToString();
                                unCan.Calle = dr["Calle"].ToString();
                                unCan.Telefono = dr["Telefono"].ToString();
                                ListadeCanchas.Add(unCan);
                            }
                        }
                    }
                }

                conn.Close();
                return ListadeCanchas;
            }

            catch (Exception e)
            {
                conn.Close();
                return ListadeCanchas;
            }
        }

    }
}