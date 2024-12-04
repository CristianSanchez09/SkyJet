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
    public partial class MostrarVuelos : Form
    {
        VueloServicio vueloServicio;
        Form vuelosUI;

        public MostrarVuelos(Form vuelo)
        {
            InitializeComponent();
            vuelosUI = vuelo;
            ResetForm();
            vueloServicio = new VueloServicio();
            LoadGrid();
        }   

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Vuelo vuelo = new Vuelo(
                txtCodVuelo.Text,
                cmbProcedencia.Text,
                cmbDestino.Text,
                dtpFechaVuelo.Value
            );
            VueloServicio servicio = new VueloServicio();

            try
            {
                vuelo.Cupos = Int32.Parse(txtCupos.Text);
            }
            catch (Exception)
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

            if ( warningMessage != null )
            {
                MessageBox.Show(warningMessage, "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ( servicio.Actualizar(vuelo) )
                {
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Actualizado Exitosamente", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El Vuelo {txtCodVuelo.Text} no fue encontrado", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ( txtCodVuelo.Text == "" )
            {
                MessageBox.Show("Debe completar el campo Codigo", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ( vueloServicio.Eliminar(txtCodVuelo.Text) )
                {
                    ResetForm();
                    LoadGrid();
                    MessageBox.Show("Eliminado Exitosamente", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El Vuelo {txtCodVuelo.Text} no fue encontrado", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ResetForm ()
        {
            txtCodVuelo.Text = "";
            cmbProcedencia.Text = "";
            cmbDestino.Text = "";
            dtpFechaVuelo.Value = DateTime.Now;
            txtCupos.Text = "";
            txtPrecio.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            vuelosUI.Visible = true;
            this.Close();
        }

        public void LoadGrid()
        {
            dgvVuelos.Rows.Clear();

            List<Vuelo> vuelos = vueloServicio.Lista();

            if (vuelos.Count == 0)
                MessageBox.Show("No se encuentran vuelos en la base de datos", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                foreach (var item in vuelos)
                {
                    dgvVuelos.Rows.Add(
                        item.Codigo,
                        item.Procedencia,
                        item.Destino,
                        item.Fecha.ToShortDateString(),
                        item.Cupos,
                        item.Precio
                    );
                }
            }
        }

        private void dgvVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int row = e.RowIndex;
                txtCodVuelo.Text = dgvVuelos.Rows[row].Cells[0].Value.ToString();
                cmbProcedencia.Text = dgvVuelos.Rows[row].Cells[1].Value.ToString();
                cmbDestino.Text = dgvVuelos.Rows[row].Cells[2].Value.ToString();
                dtpFechaVuelo.Value = Convert.ToDateTime(dgvVuelos.Rows[row].Cells[3].Value);
                txtCupos.Text = dgvVuelos.Rows[row].Cells[4].Value.ToString();
                txtPrecio.Text = dgvVuelos.Rows[row].Cells[5].Value.ToString();
            }
            
        }

        public string ValidateData(Vuelo vuelo)
        {

            if (vuelo.Codigo == "")
                return "Completar el campo: Codigo";
            if (vuelo.Procedencia == "")
                return "Completar el campo: Procedencia";
            if (vuelo.Destino == "")
                return "Completar el campo: Destino";
            if (txtCupos.Text == "")
                return "Completar el campo: N° Asiento";

            if (!ValidateCombo(cmbProcedencia, vuelo.Procedencia))
                return "El campo Procedencia no es correcto";
            if (!ValidateCombo(cmbDestino, vuelo.Destino))
                return "El campo Destino no es correcto";
            if (cmbProcedencia.Text == cmbDestino.Text)
                return "La Procedencia y el Destino son iguales";

            if (vuelo.Cupos == 0 || vuelo.Cupos < 0)
                return "El campo Cupos es númerico y mayor a cero";
            if (vuelo.Precio == 0 || vuelo.Precio < 0)
                return "El campo Precio es númerico y mayor a cero";

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

        private void txtCodVuelo_TextChanged(object sender, EventArgs e)
        {
            txtCodVuelo.Text = txtCodVuelo.Text.ToUpper();
            txtCodVuelo.SelectionStart = txtCodVuelo.Text.Length;
        }
    }
}
