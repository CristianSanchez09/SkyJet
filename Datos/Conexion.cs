using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        const String CADENA_CONEXION = @"Data Source=PC-CRISTIAN;Initial Catalog=SkyJet;Integrated Security=True;Pooling=False";

        protected SqlConnection conexion;

        // Constructor que inicializa la cadena de conexión
        public Conexion()
        {
            this.conexion = new SqlConnection(CADENA_CONEXION);
        }

        // Método para abrir la conexión
        public void Open()
        {
            try
            {
                conexion.Open();
                Console.WriteLine("La conexión se abrió correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void Close()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    Console.WriteLine("La conexión se cerro correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Método para verificar el estado de la conexión
        public bool IsOpen()
        {
            return conexion.State == System.Data.ConnectionState.Open;
        }
    }
}
