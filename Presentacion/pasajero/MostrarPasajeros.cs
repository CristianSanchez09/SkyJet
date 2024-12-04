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
    public partial class MostrarPasajeros : Form
    {
        PasajeroServicio pasajeroServicio;
        Form pasajeroUI;

        public MostrarPasajeros(Form pasajero)
        {
            InitializeComponent();
            pasajeroUI = pasajero;
            pasajeroServicio = new PasajeroServicio();
            LoadGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pasajeroUI.Visible = true;

            this.Close();
        }

        public void LoadGrid()
        {
            dgvPasajeros.Rows.Clear();

            List<Pasajero> pasajeros = pasajeroServicio.Lista();

            if (pasajeros.Count == 0)
                MessageBox.Show("No se encuentran pasajeros en la base de datos", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                foreach (var item in pasajeros)
                {
                    dgvPasajeros.Rows.Add(
                        item.Documento,
                        item.Nombre,
                        item.Pasaporte,
                        item.Direccion,
                        item.Nacionalidad,
                        item.Genero,
                        item.Celular
                    );
                }
            }
        }

        public void ResetForm()
        {
            txtDocumento.Text = "";
            txtNames.Text = "";
            txtPasaporte.Text = "";
            txtDireccion.Text = "";
            cmbNacionalidad.Text = "";
            cmbGenero.Text = "";
            txtCelular.Text = "";
        }

        private void txtPasaporte_TextChanged(object sender, EventArgs e)
        {
            txtPasaporte.Text = txtPasaporte.Text.ToUpper();
            txtPasaporte.SelectionStart = txtPasaporte.Text.Length;
        }

        private void dgvPasajeros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int row = e.RowIndex;
                txtDocumento.Text = dgvPasajeros.Rows[row].Cells[0].Value.ToString();
                txtNames.Text = dgvPasajeros.Rows[row].Cells[1].Value.ToString();
                txtPasaporte.Text = dgvPasajeros.Rows[row].Cells[2].Value.ToString();
                txtDireccion.Text = dgvPasajeros.Rows[row].Cells[3].Value.ToString();
                cmbNacionalidad.Text = dgvPasajeros.Rows[row].Cells[4].Value.ToString();
                cmbGenero.Text = dgvPasajeros.Rows[row].Cells[5].Value.ToString();
                txtCelular.Text = dgvPasajeros.Rows[row].Cells[6].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Debe completar el campo N° Documento", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (pasajeroServicio.Eliminar(txtDocumento.Text))
                {
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Eliminado Exitosamente", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El Pasajero {txtDocumento.Text} no fue encontrado", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string ValidateForm(Pasajero pasajero)
        {
            if (pasajero.Documento == "")
                return "Completar el campo N° Documento";
            if (pasajero.Nombre == "")
                return "Completar el campo Nombre";
            if (pasajero.Pasaporte == "" && pasajero.Nacionalidad != "Colombia")
                return "Completar el campo N° Pasaporte";
            if (pasajero.Nacionalidad == "")
                return "Completar el campo Nacionalidad";
            if (pasajero.Genero == "")
                return "Completar el campo Genero";

            if (!TextIsNumber(pasajero.Documento))
                return "El campo N° Documento es númerico";
            if (Int32.Parse(pasajero.Documento) <= 0)
                return "El campo N° Documento debe ser mayor a cero";

            if (!ValidateCombo(cmbNacionalidad, pasajero.Nacionalidad))
                return "El campo Nacionalidad no es correcto";

            if (!ValidateCombo(cmbGenero, pasajero.Genero))
                return "El campo Genero no es correcto";

            if (pasajero.Celular != "" && !TextIsNumber(pasajero.Celular))
                return "El campo Celular es númerico";
            if (pasajero.Celular != "" && pasajero.Celular.Length != 10)
                return "El campo Celular debe contener 10 digitos";

            return null;

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

        public bool ValidateCombo(ComboBox comboBox, string value)
        {
            foreach (var item in comboBox.Items)
            {
                if (item.ToString() == value)
                    return true;
            }

            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Pasajero pasajero = new Pasajero(
                txtDocumento.Text,
                txtNames.Text,
                txtPasaporte.Text,
                txtDireccion.Text,
                cmbNacionalidad.Text,
                cmbGenero.Text,
                txtCelular.Text
            );
            PasajeroServicio servicio = new PasajeroServicio();


            string warningMessage = ValidateForm(pasajero);

            if (warningMessage != null)
            {
                MessageBox.Show(warningMessage, "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (servicio.Actualizar(pasajero))
                {
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Actualizado Exitosamente", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El Pasajero {txtDocumento.Text} no fue encontrado", "Pasajero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
