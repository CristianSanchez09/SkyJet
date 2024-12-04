using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CancelacionBD : Conexion
    {
        public CancelacionBD() { }

        public void InsertarCancelacion(Cancelacion cancelacion)
        {
            try
            {
                Open();

                string query = "INSERT INTO [Cancelaciones] (id_ticket, codigo_vuelo, identificacion, fecha) VALUES (@ticket, @vuelo, @identificacion, @fecha)";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@ticket", cancelacion.IdTicket);
                    command.Parameters.AddWithValue("@vuelo", cancelacion.CodVuelo);
                    command.Parameters.AddWithValue("@identificacion", cancelacion.Documento);
                    command.Parameters.AddWithValue("@fecha", cancelacion.Fecha);

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

        public List<Cancelacion> ListaCancelaciones()
        {
            List<Cancelacion> cancelaciones = new List<Cancelacion>();

            try
            {
                Open();

                string query = "SELECT id, id_ticket, codigo_vuelo, identificacion, fecha FROM [Cancelaciones] ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cancelacion cancelacion = new Cancelacion();
                            cancelacion.Id = Convert.ToInt32(reader["id"].ToString());
                            cancelacion.IdTicket = Convert.ToInt32(reader["id_ticket"].ToString());
                            cancelacion.CodVuelo = reader["codigo_vuelo"].ToString();
                            cancelacion.Documento = reader["identificacion"].ToString();
                            cancelacion.Fecha = Convert.ToDateTime(reader["fecha"].ToString());

                            cancelaciones.Add(cancelacion);
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

            return cancelaciones;
        }
    }
}
