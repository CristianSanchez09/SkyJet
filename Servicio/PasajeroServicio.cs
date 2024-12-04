using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class PasajeroServicio
    {
        private PasajeroDB pasajeroDB;

        public PasajeroServicio()
        {
            pasajeroDB = new PasajeroDB();
        }

        public bool Guardar(Pasajero pasajero)
        {
            if (pasajeroDB.ExistePasajero(pasajero.Documento))
                return false;

            pasajeroDB.InsertarPasajero(pasajero);
            return true;
        }

        public List<Pasajero> Lista()
        {
            return pasajeroDB.ListaPasajeros();
        }

        public bool Eliminar(string documento)
        {
            return pasajeroDB.EliminarPasajero(documento);
        }

        public bool Actualizar(Pasajero pasajero)
        {
            return pasajeroDB.ActualizarPasajero(pasajero);
        }
    }
}
