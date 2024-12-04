using Datos;
using Entidad;
using System;
using System.Windows.Forms;

namespace Servicio
{
    public class AdminServicio
    {
        private AdminBD adminBD;

        public AdminServicio()
        {
            adminBD = new AdminBD();
        }

        public bool Login(Admin admin)
        {
            string error = ValidateData(admin);

            if (error != null)
            {
                MessageBox.Show(error, "Acceder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!adminBD.ExistAdmin(admin))
            {
                MessageBox.Show("El usuario o la contraseña es incorrecto", "Acceder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public string ValidateData(Admin admin)
        {
            if ( admin.Usuario == "" )
                return "Completar el campo: Usuario";

            if ( admin.Contrasenia == "" )
                return "Completar el campo: Contraseña";

            return null;
        }
    }
}
