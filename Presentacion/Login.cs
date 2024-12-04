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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(txtUsuario.Text, txtContrasenia.Text);
            AdminServicio adminServicio = new AdminServicio();

            if ( adminServicio.Login(admin) )
            {
                Home UI = new Home();
                UI.Show();

                this.Hide();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e) { Application.Exit(); }
    }
}
