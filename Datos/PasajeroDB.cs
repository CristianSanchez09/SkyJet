using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PasajeroDB : Conexion
    {
        public PasajeroDB() { }

        public bool ExistePasajero(string documento)
        {
            bool exists = false;

            try
            {
                Open();

                string query = "SELECT COUNT(*) FROM [Pasajeros] WHERE num_documento = @documento";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@documento", documento);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                        exists = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
            }
            finally
            {
                Close();
            }

            return exists;
        }

        public void InsertarPasajero(Pasajero pasajero)
        {
            try
            {
                Open();

                string query = "INSERT INTO [Pasajeros] (num_documento, nombre, num_pasaporte, direccion, nacionalidad, genero, celular) VALUES (@documento, @nombre, @pasaporte, @direccion, @nacionalidad, @genero, @celular)";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@documento", pasajero.Documento);
                    command.Parameters.AddWithValue("@nombre", pasajero.Nombre);
                    command.Parameters.AddWithValue("@pasaporte", pasajero.Pasaporte);
                    command.Parameters.AddWithValue("@direccion", pasajero.Direccion);
                    command.Parameters.AddWithValue("@nacionalidad", pasajero.Nacionalidad);
                    command.Parameters.AddWithValue("@genero", pasajero.Genero);
                    command.Parameters.AddWithValue("@celular", pasajero.Celular);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public List<Pasajero> ListaPasajeros()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();

            try
            {
                Open();

                string query = "SELECT num_documento, nombre, num_pasaporte, direccion, nacionalidad, genero, celular FROM [Pasajeros]";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pasajero pasajero = new Pasajero();
                            pasajero.Documento = reader["num_documento"].ToString();
                            pasajero.Nombre = reader["nombre"].ToString();
                            pasajero.Pasaporte = reader["num_pasaporte"].ToString();
                            pasajero.Direccion = reader["direccion"].ToString();
                            pasajero.Nacionalidad = reader["nacionalidad"].ToString();
                            pasajero.Genero = reader["genero"].ToString();
                            pasajero.Celular = reader["celular"].ToString();

                            pasajeros.Add(pasajero);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
            }
            finally
            {
                Close();
            }

            return pasajeros;
        }

        public bool EliminarPasajero(string documento)
        {
            try
            {
                Open();

                string query = "DELETE FROM [Pasajeros] WHERE num_documento = @documento";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@documento", documento);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
                return false;
            }
            finally
            {
                Close();
            }
        }

        public bool ActualizarPasajero(Pasajero pasajero)
        {
            try
            {
                Open();

                string query = "UPDATE [Pasajeros] SET nombre = @nombre, num_pasaporte = @pasaporte, direccion = @direccion, nacionalidad = @nacionalidad, genero = @genero, celular = @celular WHERE num_documento = @documento";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@documento", pasajero.Documento);
                    command.Parameters.AddWithValue("@nombre", pasajero.Nombre);
                    command.Parameters.AddWithValue("@pasaporte", pasajero.Pasaporte);
                    command.Parameters.AddWithValue("@direccion", pasajero.Direccion);
                    command.Parameters.AddWithValue("@nacionalidad", pasajero.Nacionalidad);
                    command.Parameters.AddWithValue("@genero", pasajero.Genero);
                    command.Parameters.AddWithValue("@celular", pasajero.Celular);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
                return false;
            }
            finally
            {
                Close();
            }
        }
    }
}
