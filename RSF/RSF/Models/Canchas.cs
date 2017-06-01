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
            Data Source=|DataDirectory|\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

        private static void ConectarDB()
        {
            conn.ConnectionString = Proveedor;
            conn.Open();
        }


        public static bool AgregarUnaCancha(Cancha canchaAAgregar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "AgregarCancha";

                OleDbParameter nombre = new OleDbParameter("nombre", canchaAAgregar.nombre);
                OleDbParameter barrio = new OleDbParameter("barrio", canchaAAgregar.barrio);
                OleDbParameter calle = new OleDbParameter("calle", canchaAAgregar.calle);
                OleDbParameter telefono = new OleDbParameter("telefono", canchaAAgregar.telefono);


                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(barrio);
                Consulta.Parameters.Add(calle);
                Consulta.Parameters.Add(telefono);


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
        public static bool ModificarUnaCancha(Cancha canchaAmodificar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "ModificarCancha";

                OleDbParameter id = new OleDbParameter("id", canchaAmodificar.id);
                OleDbParameter nombre = new OleDbParameter("nombre", canchaAmodificar.nombre);
                OleDbParameter barrio = new OleDbParameter("barrio", canchaAmodificar.barrio);
                OleDbParameter calle = new OleDbParameter("calle", canchaAmodificar.calle);
                OleDbParameter telefono = new OleDbParameter("telefono", canchaAmodificar.telefono);

                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(barrio);
                Consulta.Parameters.Add(calle);
                Consulta.Parameters.Add(telefono);
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
        public static Cancha TraerUnaCancha(Cancha unaCancha)
        {
            Cancha unaCancha2 = new Cancha();

            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerCanchas";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"].ToString()) == unaCancha.id)
                    {
                        unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                        unaCancha2.nombre = dr["Nombre"].ToString();
                        unaCancha2.barrio = dr["Barrio"].ToString();
                        unaCancha2.calle = dr["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        conn.Close();
                        return unaCancha2;
                    }
                    if (dr["Nombre"].ToString() == unaCancha.nombre)
                    {
                        unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                        unaCancha2.nombre = dr["Nombre"].ToString();
                        unaCancha2.barrio = dr["Barrio"].ToString();
                        unaCancha2.calle = dr["Calle"].ToString();
                        unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                        conn.Close();
                        return unaCancha2;
                    }
                }

                conn.Close();
                return unaCancha2;
            }

            catch (Exception e)
            {
                conn.Close();
                return unaCancha2;
            }
        }
        public static List<Cancha> TraerCanchas(Cancha unaCancha)
        {
            List<Cancha> ListadeCanchas = new List<Cancha>();
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TraerCanchas";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    Cancha unaCancha2 = new Cancha();
                    unaCancha2.id = Convert.ToInt32(dr["Id"].ToString());
                    unaCancha2.nombre = dr["Nombre"].ToString();
                    unaCancha2.barrio = dr["Barrio"].ToString();
                    unaCancha2.calle = dr["Calle"].ToString();
                    unaCancha2.telefono = Convert.ToInt32(dr["Telefono"].ToString());
                    if (unaCancha2.nombre == unaCancha.nombre)
                    {
                        ListadeCanchas.Add(unaCancha2);
                    }
                    else
                    {
                        if (unaCancha2.id == unaCancha.id)
                        {
                            ListadeCanchas.Add(unaCancha2);
                        }
                        else
                        {
                            if (unaCancha2.barrio == unaCancha.barrio)
                            {
                                ListadeCanchas.Add(unaCancha2);
                            }
                        }
                    }
                    if (unaCancha.id == 0 && unaCancha.nombre==null)
                    {
                        ListadeCanchas.Add(unaCancha2);
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
        public static bool EliminarUnaCancha(int idCancha)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "EliminarCancha";

                OleDbParameter id = new OleDbParameter("id", idCancha);

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