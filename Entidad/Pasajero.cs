using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Pasajero
    {
        public Pasajero() { }

        public Pasajero(string documento, string nombre, string pasaporte, string direccion, string nacionalidad, string genero, string celular) 
        {
            Documento = documento;
            Nombre = nombre;
            Pasaporte = pasaporte;
            Direccion = direccion;
            Nacionalidad = nacionalidad;
            Genero = genero;
            Celular = celular;
        }

        public string Documento { get; set; }

        public string Nombre { get; set; }

        public string Pasaporte { get; set; }

        public string Direccion { get; set; }

        public string Nacionalidad { get; set; }

        public string Genero { get; set; }

        public string Celular { get; set; }
    }
}
