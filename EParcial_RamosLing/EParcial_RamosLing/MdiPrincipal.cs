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
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCrudEmpleado);
            if (frm1 != null)
            {
                frm1.BringToFront();
                return;
            }

            //Si no existe un formulario, se abre uno
            frm1 = new frmCrudEmpleado();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCrudTransportista);
            if (frm1 != null)
            {
                frm1.BringToFront();
                return;
            }

            //Si no existe un formulario, se abre uno
            frm1 = new frmCrudTransportista();
            frm1.MdiParent = this;
            frm1.Show();
        }
    }
}