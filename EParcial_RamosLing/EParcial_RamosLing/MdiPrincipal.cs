using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace EParcial_RamosLing
{
    public partial class MdiPrincipal : Form
    {
        //Declaramos
        TimeSpan horaEntrada = new TimeSpan();
        Computer miComputadora = new Computer();
        String mired;

        public MdiPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Con esto evitamos que se repita el mismo formulario
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCrudCliente);
            if (frm1 != null)
            {
                frm1.BringToFront();
                return;
            }

            //Si no existe un formulario, se abre uno
            frm1 = new frmCrudCliente();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCrudEmpleado);
            if (frm2 != null)
            {
                frm2.BringToFront();
                return;
            }

            //Si no existe un formulario, se abre uno
            frm2 = new frmCrudEmpleado();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm3 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCrudTransportista);
            if (frm3 != null)
            {
                frm3.BringToFront();
                return;
            }

            //Si no existe un formulario, se abre uno
            frm3 = new frmCrudTransportista();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void salirDelAplicativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MdiPrincipal_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Sistemas Villaze - " + DateTime.Now;

            lblSesion.Text = "Tiempo de sesion: " +
                DateTime.Now.TimeOfDay.Subtract(horaEntrada).ToString().Substring(0, 8);
        }

        private void MdiPrincipal_Load(object sender, EventArgs e)
        {
            //Guardamos la hora en que se carga el formulario
            horaEntrada = DateTime.Now.TimeOfDay;

            //obtenemos informacion del equipo
            if (miComputadora.Network.IsAvailable == true)
            {
                mired = "Equipo con conexion a red disponible";
            }
            else
            {
                mired = "Equipo no cuenta con conexion a red disponible";
            }

            //Mostramosa informacion en lblUsuario
            lblUsuario.Text = "Equipo: " + miComputadora.Name + " - " + mired;
        }
    }
}