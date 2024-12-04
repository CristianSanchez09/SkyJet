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

namespace Presentacion.reserva
{
    public partial class CancelacionUI : Form
    {
        Form homeUI;
        CancelacionServicio cancelacionServicio;

        public CancelacionUI(Form home)
        {
            InitializeComponent();
            homeUI = home;
            ResetForm();
            cancelacionServicio = new CancelacionServicio();
            LoadGrid();
            LoadCombo(cmbTicketId, cancelacionServicio.ListaTicketId());
            cmbTicketId.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homeUI.Visible = true;

            this.Close();
        }

        public void ResetForm()
        {
            cmbTicketId.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cancelacion cancelacion = new Cancelacion();

            try
            {
                cancelacion.IdTicket = Int32.Parse(cmbTicketId.Text);
            }
            catch (Exception)
            {
                cancelacion.IdTicket = 0;
            }


            if (cmbTicketId.Text == "")
                MessageBox.Show("Debe seleccionar un Ticket", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (cancelacionServicio.TicketVencido(cancelacion.IdTicket))
                {
                    MessageBox.Show("El Ticket ya no es posible cancelarlo", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    cancelacionServicio.Agregar(cancelacion);
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Cancelado Exitosamente", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        public void LoadGrid()
        {
            dgvCancelaciones.Rows.Clear();

            List<Cancelacion> cancelaciones = cancelacionServicio.Lista();

            if (cancelaciones.Count != 0)
            {
                foreach (var item in cancelaciones)
                {
                    dgvCancelaciones.Rows.Add(
                        item.Id,
                        item.IdTicket,
                        item.CodVuelo,
                        item.Documento,
                        item.Fecha.ToShortDateString()
                    );
                }
            }
        }

        private void cmbTicketId_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
