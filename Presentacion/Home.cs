using Presentacion.reserva;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPasajeros_Click(object sender, EventArgs e)
        {
            GuardarPasajero UI = new GuardarPasajero(this);

            OpenForm(UI);
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            TicketUI UI = new TicketUI(this);

            OpenForm(UI);
        }

        private void btnVuelos_Click_1(object sender, EventArgs e)
        {
            GuardarVuelo UI = new GuardarVuelo(this);

            OpenForm(UI);
        }

        private void btnCancelacion_Click(object sender, EventArgs e)
        {
            CancelacionUI UI = new CancelacionUI(this);

            OpenForm(UI);
        }

        public void OpenForm(Form UI)
        {
            UI.Show();
            this.Visible = false;
        }
    }
}
