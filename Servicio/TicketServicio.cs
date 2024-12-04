using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class TicketServicio
    {
        private TicketBD ticketBD;
        private VueloDB vueloDB;
        private PasajeroDB pasajeroDB;

        public TicketServicio()
        {
            ticketBD = new TicketBD();
            vueloDB = new VueloDB();
            pasajeroDB = new PasajeroDB();
        }

        public void Agregar(Ticket ticket)
        {
            Vuelo vuelo = GetVuelo(ticket.CodigoVuelo);
            ticket.Total = ticket.Cantidad * vuelo.Precio;
            ticketBD.InsertarTicket(ticket);
            vueloDB.ActualizarCupos(ticket.CodigoVuelo, vuelo.Cupos - ticket.Cantidad);
        }

        public List<Ticket> Lista()
        {
            return ticketBD.ListaTickets();
        }

        public bool ExisteTicket(int id)
        {
            return ticketBD.ExisteTicket(id);
        }

        public bool VueloNoPosible(Ticket ticket)
        {
            Console.WriteLine(GetVuelo(ticket.CodigoVuelo).Fecha);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(GetVuelo(ticket.CodigoVuelo).Fecha < DateTime.Now);
            return GetVuelo(ticket.CodigoVuelo).Fecha < DateTime.Now;
        }

        public bool VueloSinCupo(Ticket ticket)
        {
            Vuelo vuelo = GetVuelo(ticket.CodigoVuelo);
            return ticket.Cantidad > vuelo.Cupos;
        }

        public List<string> ListaCodigoVuelo()
        {
            List<string> list = new List<string>();

            foreach (var item in vueloDB.ListaVuelos())
            {
                if (item.Fecha >= DateTime.Now)
                {
                    list.Add(item.Codigo);
                }
            }

            return list;
        }

        public List<string> ListaNumDocumento()
        {
            List<string> list = new List<string>();

            foreach(var item in pasajeroDB.ListaPasajeros())
            {
                list.Add(item.Documento);
            }

            return list;
        }

        public Vuelo GetVuelo(string codigo)
        {
            Vuelo vuelo = null;

            foreach (var item in vueloDB.ListaVuelos())
            {
                if (codigo == item.Codigo)
                    vuelo = item;
            }

            return vuelo;
        }

        public Pasajero GetPasajero(string documento)
        {
            Pasajero pasajero = null;

            foreach(var item in pasajeroDB.ListaPasajeros())
            {
                if (documento == item.Documento)
                    pasajero = item;
            }

            return pasajero;
        }
    }
}
