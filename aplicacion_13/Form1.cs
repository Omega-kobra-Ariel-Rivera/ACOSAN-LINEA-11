using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacion_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Aquí puedes poner la lógica de autenticación, como comparar con una base de datos
            if (usuario == "admin" && contraseña == "1234")
            {
                MessageBox.Show("Bienvenido, " + usuario + "!");
                // Abre el formulario principal de la aplicación
                Linea_11 mainForm = new Linea_11(this); // Cambia Form1 por el nombre de tu formulario
                mainForm.Show();
                this.Hide(); // Oculta el formulario de login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lbContraseña_Click(object sender, EventArgs e)
        {

        }
    }
}
