using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EParcial_RamosLing
{
    public partial class frmLogin : Form
    {

        int tiempo = 20;
        int intentos = 0;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            if (txtUsuario.Text.Trim() != "" & txtContraseña.Text.Trim() != "")
            {
                //Validamos las credenciales
                if (txtUsuario.Text == "ISIL" & txtContraseña.Text == "12345")
                {
                    //Si las credenciales son correctas
                    this.Hide(); //Ocultamos el login
                    timer1.Enabled = false;
                    MdiPrincipal mdi = new MdiPrincipal();
                    mdi.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectas",
                                    "Mensaje", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    intentos += 1;
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña obligatorias!",
                                 "Mensaje", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                intentos += 1;
            }

            if (intentos == 3)
            {
                MessageBox.Show("Lo sentimos sobrepaso el numeros de intentos",
                                "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo -= 1;
            this.Text = "Ingrese su usuario y contraseña. Le quedan: " + tiempo;

            if (tiempo == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Lo sentimos se le acabo el tiempo",
                                "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Application.Exit();
            }
        }

       
    }
}
