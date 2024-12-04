using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Ticket
    {
        public Ticket() { }

        public Ticket(string codigoVuelo, string numDocumento, string nombre, string numPasaporte, string nacionalidad)
        {
            CodigoVuelo = codigoVuelo;
            NumDocumento = numDocumento;
            Nombre = nombre;
            NumPasaporte = numPasaporte;
            Nacionalidad = nacionalidad;
        }

        public int Id { get; set; }
        public string CodigoVuelo { get; set; }
        public string NumDocumento { get; set; }
        public string Nombre { get; set; }
        public string NumPasaporte { get; set; }
        public string Nacionalidad { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}
