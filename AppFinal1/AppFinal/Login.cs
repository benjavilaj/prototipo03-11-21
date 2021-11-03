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
    public partial class Login : Form
    {
        Conexion cn = new Conexion();

        public Login()
        {
            InitializeComponent();

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int result = cn.login(txtUsuario.Text, txtPass.Text);

            if(result == 1)
            {
                Registro registro = new Registro();
                this.Hide();
                registro.ShowDialog();
            }
            else if(result == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

      

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnEntrar.PerformClick();
            }
        }
    }
}
