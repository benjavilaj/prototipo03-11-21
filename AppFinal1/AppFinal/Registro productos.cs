using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFinal1;


namespace AppFinal
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            cmbCategoría.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        Conexion cn = new Conexion();
        
       

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = cn.mostrar("select * from productos");
        }

      
                                                                                                         
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string guardar = "insert into productos values( " + txtCódigo.Text + ", ' " + txtDescripción.Text + " ', ' " + cmbCategoría.Text + "')";

            if (cn.agregar(guardar))
            {
                MessageBox.Show("Producto guardado");

            }
            else
            {
                MessageBox.Show("Error");
            }


        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "delete from productos where código = " + txtBusquedaCódigo.Text;

            if (cn.eliminar(eliminar)) 
            {
                MessageBox.Show("Desea eliminar");
                              
            }

            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            txtCódigo.Text = " ";
            txtDescripción.Text = " ";
            cmbCategoría.Text = " ";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string actualizar = " update productos set Descripción= '" + txtDescripción.Text + "', Categoría= '" + cmbCategoría.Text + "' where código = '" + txtCódigo.Text + "'";
            if (cn.actualizar(actualizar))
            {
                MessageBox.Show("Producto actualizado");
                
            }

            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

                   

        private void btnBuscarCódigo_Click(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = cn.mostrarCódigo("select * from productos where código = " + txtBusquedaCódigo.Text);

            txtCódigo.Text = " ";
            txtDescripción.Text = " ";
            cmbCategoría.Text = " ";
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
                      
        }

       

        private void txtBusquedaCódigo_KeyDown(object sender, KeyEventArgs e)
        {









            if (e.KeyData == Keys.Enter)
            {
                btnBuscarCódigo.PerformClick();
            }
        }

        private void txtCódigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnNuevo.Focus();
                txtDescripción.Focus();
               
            }
           
        }

        private void txtDescripción_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cmbCategoría.Focus();
            }
        }

        private void cmbCategoría_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //abre la ventana para ingresar nuevos datos 
            Agregar_Datos agregarDatos = new Agregar_Datos();
            agregarDatos.Show();
            this.Close();
        }
    }

}
