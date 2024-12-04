using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TicketBD : Conexion
    {
        public TicketBD() { }

        public bool ExisteTicket(int id)
        {
            bool exists = false;

            try
            {
                Open();

                string query = "SELECT COUNT(*) FROM [Tickets] WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@id", id);

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

        public void InsertarTicket(Ticket ticket)
        {
            try
            {
                Open();

                string query = "INSERT INTO [Tickets] (id, cod_vuelo, num_documento, nombre, num_pasaporte, nacionalidad, cantidad, total) VALUES (@id, @codigo, @documento, @nombre, @pasaporte, @nacionalidad, @cantidad, @total)";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@id", ticket.Id);
                    command.Parameters.AddWithValue("@codigo", ticket.CodigoVuelo);
                    command.Parameters.AddWithValue("@documento", ticket.NumDocumento);
                    command.Parameters.AddWithValue("@nombre", ticket.Nombre);
                    command.Parameters.AddWithValue("@pasaporte", ticket.NumPasaporte);
                    command.Parameters.AddWithValue("@nacionalidad", ticket.Nacionalidad);
                    command.Parameters.AddWithValue("@cantidad", ticket.Cantidad);
                    command.Parameters.AddWithValue("@total", ticket.Total);

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

        public List<Ticket> ListaTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                Open();

                string query = "SELECT id, cod_vuelo, num_documento, nombre, num_pasaporte, nacionalidad, cantidad, total FROM [Tickets] ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ticket ticket = new Ticket();
                            ticket.Id = Convert.ToInt32(reader["id"].ToString());
                            ticket.CodigoVuelo = reader["cod_vuelo"].ToString();
                            ticket.NumDocumento = reader["num_documento"].ToString();
                            ticket.Nombre = reader["nombre"].ToString();
                            ticket.NumPasaporte = reader["num_pasaporte"].ToString();
                            ticket.Nacionalidad = reader["nacionalidad"].ToString();
                            ticket.Cantidad = Convert.ToInt32(reader["cantidad"].ToString());
                            ticket.Total = Convert.ToDouble(reader["total"].ToString());

                            tickets.Add(ticket);
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

            return tickets;
        }

        public void EliminarTicketPorId(int id)
        {
            try
            {
                Open();

                string query = "DELETE FROM [Tickets] WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@id", id);

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
    }
}
