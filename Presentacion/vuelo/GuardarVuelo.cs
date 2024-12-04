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
    public partial class GuardarVuelo : Form
    {
        Form homeUI;

        public GuardarVuelo(Form home)
        {
            InitializeComponent();
            homeUI = home;
            ResetForm();

            dtpFecha.MinDate = DateTime.Now;
            cmbProcedencia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Vuelo vuelo = new Vuelo(
                txtCodVuelo.Text,
                cmbProcedencia.Text,
                cmbDestino.Text,
                dtpFecha.Value
            );
            VueloServicio servicio = new VueloServicio();

            try
            {
                vuelo.Cupos = Int32.Parse(txtCupos.Text);
            } catch (Exception)
            {
                vuelo.Cupos = 0;
            }

            try
            {
                vuelo.Precio = Double.Parse(txtPrecio.Text);
            }
            catch (Exception)
            {
                vuelo.Precio = 0;
            }

            string warningMessage = ValidateData(vuelo);

            if (warningMessage != null )
                MessageBox.Show(warningMessage, "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if ( servicio.Agregar(vuelo))
                {
                    ResetForm();
                    MessageBox.Show("Guardado Exitosamente", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                    MessageBox.Show($"El Vuelo {vuelo.Codigo} ya existe", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFechaVuelo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Vuelo_Load(object sender, EventArgs e)
        {
            dtpFecha.CalendarTitleForeColor = Color.Navy;    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            homeUI.Visible = true;
            this.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            MostrarVuelos UI = new MostrarVuelos(this);
            UI.Show();

            this.Visible = false;
        }

        public void ResetForm()
        {
            txtCodVuelo.Text = "";
            cmbProcedencia.Text = "";
            cmbDestino.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtCupos.Text = "";
            txtPrecio.Text = "";
        }

        public string ValidateData(Vuelo vuelo)
        {

            if ( vuelo.Codigo == "" )
                return "Completar el campo: Codigo";
            if ( vuelo.Procedencia == "" )
                return "Completar el campo: Procedencia";
            if ( vuelo.Destino == "" )
                return "Completar el campo: Destino";
            if ( txtCupos.Text == "" )
                return "Completar el campo: N° Asiento";

            if ( !ValidateCombo(cmbProcedencia, vuelo.Procedencia) )
                return "El campo Procedencia no es correcto";
            if ( !ValidateCombo(cmbDestino, vuelo.Destino) )
                return "El campo Destino no es correcto";
            if ( cmbProcedencia.Text == cmbDestino.Text )
                return "La Procedencia y el Destino son iguales";

            if ( vuelo.Cupos == 0 || vuelo.Cupos < 0 )
                return "El campo Cupos es númerico y mayor a cero";
            if (vuelo.Precio == 0 || vuelo.Precio < 0)
                return "El campo Precio es númerico y mayor a cero";

            return null;
        }

        public bool ValidateCombo(ComboBox comboBox, string value)
        {
            foreach (var item in comboBox.Items)
            {
                if ( item.ToString() == value )
                    return true;
            }

            return false;
        }

        private void txtCodVuelo_TextChanged(object sender, EventArgs e)
        {
            txtCodVuelo.Text = txtCodVuelo.Text.ToUpper();
            txtCodVuelo.SelectionStart = txtCodVuelo.Text.Length;
        }

        private void cmbProcedencia_SelectedValueChanged(object sender, EventArgs e)
        {
            generateCodigo();
        }

        private void cmbDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProcedencia.Text != "")
            {
                generateCodigo();
            }
        }

        public void generateCodigo ()
        {
            string codProcedencia;
            string espacing = cmbDestino.Text == "" ? "" : "-";
            if (!cmbProcedencia.Text.Contains(" "))
            {
                codProcedencia = cmbProcedencia.Text.Substring(0, 2).ToUpper() + espacing;
            }
            else
            {
                string[] palabras = cmbProcedencia.Text.Split(' ');
                codProcedencia = $"{palabras[0][0]}{palabras[1][0]}".ToUpper() + espacing;
            }
            if (cmbDestino.Text != "")
            {
                string codDestino;
                if (!cmbDestino.Text.Contains(" "))
                {
                    codDestino = cmbDestino.Text.Substring(0, 2).ToUpper();
                }
                else
                {
                    string[] palabras = cmbDestino.Text.Split(' ');
                    codDestino = $"{palabras[0][0]}{palabras[1][0]}".ToUpper();
                }
                txtCodVuelo.Text = txtCodVuelo.Text + codDestino;
                codProcedencia = codProcedencia + codDestino;
            }
            txtCodVuelo.Text = codProcedencia;
        }
    }
}
