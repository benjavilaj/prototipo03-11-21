using AppFinal1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFinal
{
    public partial class Agregar_Datos : Form
    {
        Conexion cn = new Conexion();
        public Agregar_Datos()
        {
            InitializeComponent();
            cmbcateg.DropDownStyle = ComboBoxStyle.DropDownList;

            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string agregar = "insert into productos values( " + txtcodigo.Text + ", ' " + txtdescrip.Text + " ', ' " + cmbcateg.Text + "')";

            if (cn.insertar(agregar))
            {
                MessageBox.Show("Producto agregado");
                txtcodigo.Clear();
                txtdescrip.Clear();

            }

            else
            {
                MessageBox.Show("Producto no agregado");
            }
            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtcodigo.Text = " ";
            txtdescrip.Text = " ";
            cmbcateg.Text = " ";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           //se cierra la ventana pero al cerrar la aplicación sigue corriendo 
            Registro registroProductos = new Registro();
            registroProductos.Show();
            this.Close();

        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtdescrip.Focus();
            }
        }

        private void txtdescrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cmbcateg.Focus();
            }
        }

        private void cmbcateg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }
    }
}
