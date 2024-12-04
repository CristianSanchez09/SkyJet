using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class VueloDB : Conexion
    {
        public VueloDB() { }

        public bool ExistVuelo(string codigo)
        {
            bool exists = false;

            try
            {
                Open();

                string query = "SELECT COUNT(*) FROM [Vuelos] WHERE codigo = @codigo";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);

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

        public void InsertarVuelo(Vuelo vuelo)
        {
            try
            {
                Open();

                string query = "INSERT INTO [Vuelos] (codigo, procedencia, destino, fecha, cupos, precio) VALUES (@codigo, @procedencia, @destino, @fecha, @cupos, @precio)";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@codigo", vuelo.Codigo);
                    command.Parameters.AddWithValue("@procedencia", vuelo.Procedencia);
                    command.Parameters.AddWithValue("@destino", vuelo.Destino);
                    command.Parameters.AddWithValue("@fecha", vuelo.Fecha);
                    command.Parameters.AddWithValue("@cupos", vuelo.Cupos);
                    command.Parameters.AddWithValue("@precio", vuelo.Precio);

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

        public List<Vuelo> ListaVuelos()
        {
            List<Vuelo> vuelos = new List<Vuelo>();

            try
            {
                Open();

                string query = "SELECT codigo, procedencia, destino, fecha, cupos, precio FROM [Vuelos] ORDER BY fecha DESC";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vuelo vuelo = new Vuelo();
                            vuelo.Codigo = reader["codigo"].ToString();
                            vuelo.Procedencia = reader["procedencia"].ToString();
                            vuelo.Destino = reader["destino"].ToString();
                            vuelo.Fecha = Convert.ToDateTime(reader["fecha"]);
                            vuelo.Cupos = Convert.ToInt32(reader["cupos"]);
                            vuelo.Precio = Convert.ToDouble(reader["precio"]);

                            vuelos.Add(vuelo);
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

            return vuelos;
        }

        public bool EliminarVuelo(string codigo)
        {
            try
            {
                Open();

                string query = "DELETE FROM [Vuelos] WHERE codigo = @codigo";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);

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

        public bool ActualizarVuelo(Vuelo vuelo)
        {
            try
            {
                Open();

                string query = "UPDATE [Vuelos] SET procedencia = @procedencia, destino = @destino, fecha = @fecha, cupos = @cupos, precio = @precio WHERE codigo = @codigo";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@codigo", vuelo.Codigo);
                    command.Parameters.AddWithValue("@procedencia", vuelo.Procedencia);
                    command.Parameters.AddWithValue("@destino", vuelo.Destino);
                    command.Parameters.AddWithValue("@fecha", vuelo.Fecha);
                    command.Parameters.AddWithValue("@cupos", vuelo.Cupos);
                    command.Parameters.AddWithValue("@precio", vuelo.Precio);

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

        public void ActualizarCupos(string codigo, int cupos)
        {
            try
            {
                Open();

                string query = "UPDATE [Vuelos] SET cupos = @cupos WHERE codigo = @codigo";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@cupos", cupos);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un Error en la Consulta: " + ex.Message);
                return;
            }
            finally
            {
                Close();
            }
        }
    }
}
