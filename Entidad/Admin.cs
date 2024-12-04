using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Admin
    {
        public Admin() { }

        public Admin(string usuario, string contrasenia)
        {
            Usuario = usuario;
            Contrasenia = contrasenia;
        }

        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
