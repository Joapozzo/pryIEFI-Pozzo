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
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string pais = cmbPaises.SelectedItem.ToString();

        }
    }
}
