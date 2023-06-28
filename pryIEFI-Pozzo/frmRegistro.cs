using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace pryIEFI_Pozzo
{
    public partial class frmIEFI : Form
    {
        public frmIEFI()
        {
            InitializeComponent();
        }

        private void frmIEFI_Load(object sender, EventArgs e)
        {
            clsConn objConn = new clsConn();
            objConn.cargarCombo(cmbPaises);
        }

        private void btnAgregarPais_Click(object sender, EventArgs e)
        {
            if (txtAgregarPais.Text == "")
            {
                MessageBox.Show("Ingrese un campo");
                return;
            }
            else
            {
                clsConn objConn = new clsConn();
                objConn.cargarPais(txtAgregarPais.Text);
                objConn.cargarCombo(cmbPaises);
            }
            txtAgregarPais.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            //declaracion de variables
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string pais = cmbPaises.SelectedItem.ToString();
            int edad = (int)nudEdad.Value;
            bool esMasculino = optMasc.Checked;
            decimal importe = decimal.Parse(txtImporte.Text);
            int puntaje = int.Parse(txtPuntaje.Text);

            // Limpiar los campos después de agregar un socio
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbPaises.SelectedIndex = -1;
            nudEdad.Value = 0;
            optFem.Checked = false;
            optMasc.Checked = false;
            txtImporte.Text = "";
            txtPuntaje.Text = "";

            if (nudEdad.Value < 49 && importe < 1000 && puntaje < 130)
            {
                //instancia de objeto
                clsConn objConn = new clsConn();
                objConn.agregarSocio(nombre, apellido, pais, edad, esMasculino, importe, puntaje);

                MessageBox.Show("Socio agregado con éxito.");
            }
            else
            {
                MessageBox.Show("RECUERDE: Edad mayor a 49, Importe mayor a $1000, Puntaje mayor a 130",
                "Mensaje de Alerta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text != "")
            {
                cmbPaises.Enabled = true;
            }
            else
            {
                cmbPaises.Enabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedIndex != -1)
            {
                nudEdad.Enabled = true;
            }
            else
            {
                nudEdad.Enabled = false;
            }
        }

        private void nudEdad_ValueChanged(object sender, EventArgs e)
        {
            if (nudEdad.Value != 0)
            {
                mrcSexo.Enabled = true;
            }
            else
            {
                mrcSexo.Enabled = false;
            }
        }

        private void optMasc_CheckedChanged(object sender, EventArgs e)
        {
            if (optMasc.Checked == true)
            {
                txtImporte.Enabled = true;
            }
            else
            {
                txtImporte.Enabled= false;
            }
        }

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {
            if (txtPuntaje.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            if (txtImporte.Text != "")
            {
                txtPuntaje.Enabled = true;
            }
            else
            {
                txtPuntaje.Enabled = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es una letra ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es una letra ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtPuntaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }
    }
}
