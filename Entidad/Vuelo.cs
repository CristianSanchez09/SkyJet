using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Vuelo
    {
        public Vuelo() { }

        public Vuelo(string codigo, string procedencia, string destino, DateTime fecha)
        {
            Codigo = codigo;
            Procedencia = procedencia;
            Destino = destino;
            Fecha = fecha;
        }

        public Vuelo(string codigo, string procedencia, string destino, DateTime fecha, int cupos, double precio)
        {
            Codigo = codigo;
            Procedencia = procedencia;
            Destino = destino;
            Fecha = fecha;
            Cupos = cupos;
            precio = precio;
        }

        public string Codigo { get; set; }
        public string Procedencia { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public int Cupos { get; set; }
        public double Precio { get; set; }
    }
}