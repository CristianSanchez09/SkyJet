using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class CancelacionServicio
    {
        private CancelacionBD cancelacionBD;
        private TicketBD ticketBD;
        private VueloDB vueloDB;
        public CancelacionServicio()
        {
            ticketBD = new TicketBD();
            cancelacionBD = new CancelacionBD();
            vueloDB = new VueloDB();
        }

        public void Agregar(Cancelacion cancelacion)
        {
            Ticket ticket = GetTicket(cancelacion.IdTicket);
            Vuelo vuelo = GetVuelo(ticket.CodigoVuelo);

            cancelacion.CodVuelo = ticket.CodigoVuelo;
            cancelacion.Documento = ticket.NumDocumento;
            cancelacion.Fecha = DateTime.Now;

            cancelacionBD.InsertarCancelacion(cancelacion);
            ticketBD.EliminarTicketPorId(cancelacion.IdTicket);
            vueloDB.ActualizarCupos(ticket.CodigoVuelo, vuelo.Cupos + ticket.Cantidad);
        }

        public List<Cancelacion> Lista()
        {
            return cancelacionBD.ListaCancelaciones();
        }

        public List<int> ListaTicketId()
        {
            List<int> list = new List<int>();

            foreach (var item in ticketBD.ListaTickets())
            {
                list.Add(item.Id);
            }

            return list;
        }

        public bool TicketVencido (int idTicket)
        {
            return GetVuelo(GetTicket(idTicket).CodigoVuelo).Fecha < DateTime.Now;
        }

        public Ticket GetTicket(int id)
        {
            Ticket ticket = null;

            foreach (var item in ticketBD.ListaTickets())
            {
                if (id == item.Id)
                    ticket = item;
            }

            return ticket;
        }

        public Vuelo GetVuelo(string cod)
        {
            Vuelo vuelo = null;

            foreach (var item in vueloDB.ListaVuelos())
            {
                if (cod == item.Codigo)
                    vuelo = item;
            }

            return vuelo;
        }
    }
}
