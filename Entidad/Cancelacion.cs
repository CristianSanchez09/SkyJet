using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cancelacion
    {
        public Cancelacion() { }

        public Cancelacion(string codVuelo, DateTime fecha)
        {
            CodVuelo = codVuelo;
            Fecha = fecha;
        }

        public int Id { get; set; }
        public int IdTicket { get; set; }
        public string CodVuelo { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
    }
}
