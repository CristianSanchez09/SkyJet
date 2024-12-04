using Entidad;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class TicketUI : Form
    {
        private TicketServicio ticketServicio;
        Form homeUI;

        public TicketUI(Form home)
        {
            InitializeComponent();
            homeUI = home;
            ResetForm();
            ticketServicio = new TicketServicio();
            LoadGrid();
            LoadCombo(cmbCodVuelo, ticketServicio.ListaCodigoVuelo());
            LoadCombo(cmbPasajeroId, ticketServicio.ListaNumDocumento());
            cmbCodVuelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPasajeroId.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homeUI.Visible = true;

            this.Close();
        }

        public void ResetForm()
        {
            txtTicketId.Text = "";
            cmbCodVuelo.Text = "";
            cmbPasajeroId.Text = "";
            txtNamesPasajero.Text = "";
            txtPasaporte.Text = "";
            txtNacionalidad.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket(
                cmbCodVuelo.Text,
                cmbPasajeroId.Text,
                txtNamesPasajero.Text,
                txtPasaporte.Text,
                txtNacionalidad.Text
            );

            try
            {
                ticket.Id = Int32.Parse(txtTicketId.Text);
            }
            catch (Exception)
            {
                ticket.Id = 0;
            }

            try
            {
                ticket.Cantidad = Int32.Parse(txtCantidad.Text);
            }
            catch (Exception)
            {
                ticket.Cantidad = 0;
            }

            try
            {
                ticket.Total = Double.Parse(txtTotal.Text);
            }
            catch (Exception)
            {
                ticket.Total = 0;
            }


            string warningMessage = ValidateData(ticket);

            if (warningMessage != null)
                MessageBox.Show(warningMessage, "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if ( ticketServicio.ExisteTicket(ticket.Id) )
                {
                    MessageBox.Show($"El Ticket {ticket.Id} ya existe", "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ticketServicio.VueloNoPosible(ticket))
                {
                    MessageBox.Show($"El Vuelo {ticket.CodigoVuelo} ya no esta disponible", "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ticketServicio.VueloSinCupo(ticket))
                {
                    MessageBox.Show($"El Vuelo {ticket.CodigoVuelo} no tiene cupos disponibles", "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ticketServicio.Agregar(ticket);
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Agregado Exitosamente", "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool TextIsNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public string ValidateData(Ticket ticket)
        {
            if (txtTicketId.Text == "")
                return "Completar el campo Ticket Id";
            if (ticket.CodigoVuelo == "")
                return "Completar el campo Codigo Vuelo";
            if (ticket.NumDocumento == "")
                return "Completar el campo N° Documento";
            if (txtCantidad.Text == "")
                return "Completar el campo Cantidad";

            if ( ticket.Id == 0 || ticket.Id < 0 )
                return "El campo Ticket Id es númerico y mayor a cero";

            if ( !ValidateCombo(cmbCodVuelo, ticket.CodigoVuelo) )
                return "El campo Codigo Vuelo no es correcto";
            if (!ValidateCombo(cmbPasajeroId, ticket.NumDocumento))
                return "El campo N° Documento no es correcto";

            if (ticket.Cantidad == 0 || ticket.Cantidad < 0)
                return "El campo Cantidad es númerico y mayor a cero";
            if (ticket.Total == 0 || ticket.Total < 0)
                return "El campo Total es númerico y mayor a cero";

            return null;
        }

        public bool ValidateCombo(ComboBox comboBox, string value)
        {
            foreach (var item in comboBox.Items)
            {
                if (item.ToString() == value)
                    return true;
            }

            return false;
        }

        public void LoadCombo<T>(ComboBox combo, List<T> lista)
        {
            combo.Items.Clear();

            foreach (T item in lista)
            {
                combo.Items.Add(item);
            }

            if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
        }

        private void cmbPasajeroId_SelectedValueChanged(object sender, EventArgs e)
        {
            Pasajero pasajero = ticketServicio.GetPasajero(cmbPasajeroId.Text);

            txtNamesPasajero.Text = pasajero.Nombre;
            txtPasaporte.Text = pasajero.Pasaporte;
            txtNacionalidad.Text = pasajero.Nacionalidad;
        }

        public void LoadGrid()
        {
            dgvTickets.Rows.Clear();

            List<Ticket> tickets = ticketServicio.Lista();

            if (tickets.Count != 0)
            {
                foreach (var item in tickets)
                {
                    dgvTickets.Rows.Add(
                        item.Id,
                        item.CodigoVuelo,
                        item.NumDocumento,
                        item.Nombre,
                        item.NumPasaporte,
                        item.Nacionalidad,
                        item.Cantidad,
                        item.Total
                    );
                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                Vuelo vuelo = ticketServicio.GetVuelo(cmbCodVuelo.Text);

                int cantidad;

                try
                {
                    cantidad = Int32.Parse(txtCantidad.Text);
                }
                catch (Exception)
                {
                    cantidad = 0;
                }

                txtTotal.Text = $"{vuelo.Precio*cantidad}".ToString();
            }
        }
    }
}