using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace RSF.Models.DataAccess
{
    public class Usuarios
    {
        static string Proveedor = @"Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source=D:\Users\42498978\Desktop\RSF\RSF\Database1.accdb";

        static OleDbConnection conn = new OleDbConnection();

        private static void ConectarDB()
        {
            conn.ConnectionString = Proveedor;
            conn.Open();
        }


        public static bool GuardarUsuario(Usuario usuarioAGuardar)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "GuardarUsuario";

                OleDbParameter nombre = new OleDbParameter("nombre", usuarioAGuardar.nombre);
                OleDbParameter contraseña = new OleDbParameter("contraseña", usuarioAGuardar.contraseña);
                OleDbParameter apellido = new OleDbParameter("apellido", usuarioAGuardar.apellido);
                OleDbParameter edad = new OleDbParameter("edad", Convert.ToInt32(usuarioAGuardar.edad));
                OleDbParameter telefono = new OleDbParameter("telefono", Convert.ToInt32(usuarioAGuardar.telefono));
                OleDbParameter email = new OleDbParameter("email", usuarioAGuardar.email);


                Consulta.Parameters.Add(nombre);
                Consulta.Parameters.Add(contraseña);
                Consulta.Parameters.Add(apellido);
                Consulta.Parameters.Add(edad);
                Consulta.Parameters.Add(telefono);
                Consulta.Parameters.Add(email);



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

        public static bool existeUsuario(Usuario unUsuario)
        {
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TodosUsuarios";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    string email = dr["Email"].ToString();
                    string contraseña = dr["Contraseña"].ToString();

                    if (email == unUsuario.email && contraseña == unUsuario.contraseña)
                    {
                        conn.Close();
                        return true;
                    }
                }

                conn.Close();
                return false;
            }

            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }

        public static List<Usuario> buscarJugadores(Usuario unUsuario)
        {
            List<Usuario> ListadeJugadores = new List<Usuario>();
            try
            {
                ConectarDB();

                OleDbCommand Consulta = conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.StoredProcedure;
                Consulta.CommandText = "TodosUsuarios";

                OleDbDataReader dr = Consulta.ExecuteReader();
                while (dr.Read())
                {
                    if (unUsuario.nombre != null)
                    {
                        if (unUsuario.nombre == dr["Nombre"].ToString())
                        {
                            Usuario unUsu = new Usuario();
                            unUsu.nombre = dr["Nombre"].ToString();
                            unUsu.id = dr["Id"].ToString();
                            unUsu.contraseña = dr["Contraseña"].ToString();
                            ListadeJugadores.Add(unUsu);
                        }
                    }
                    else
                    {
                        if (unUsuario.id == dr["Id"].ToString())
                        {
                            Usuario unUsu = new Usuario();
                            unUsu.nombre = dr["Nombre"].ToString();
                            unUsu.id = dr["Id"].ToString();
                            unUsu.contraseña = dr["Contraseña"].ToString();
                            ListadeJugadores.Add(unUsu);
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

    }
}