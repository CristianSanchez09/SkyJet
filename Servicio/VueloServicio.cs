using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class VueloServicio
    {
        private VueloDB vueloDB;

        public VueloServicio()
        {
            vueloDB = new VueloDB();
        }


        public bool Agregar(Vuelo vuelo)
        {
            if ( vueloDB.ExistVuelo(vuelo.Codigo) ) 
                return false;

            vueloDB.InsertarVuelo(vuelo);
            return true;
        }

        public List<Vuelo> Lista()
        {
            return vueloDB.ListaVuelos();
        }

        public bool Eliminar(string codigo)
        {
            return vueloDB.EliminarVuelo(codigo);
        }

        public bool Actualizar(Vuelo vuelo)
        {
            return vueloDB.ActualizarVuelo(vuelo);
        }
    }
}