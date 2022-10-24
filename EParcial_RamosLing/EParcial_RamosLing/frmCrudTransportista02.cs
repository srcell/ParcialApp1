using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Agregar...
using ProyVillaze_BE;
using ProyVillaze_BL;

namespace EParcial_RamosLing
{
    public partial class frmCrudTransportista02 : Form
    {
        // Instancias...
        TransportistaBL objTransportistaBL = new TransportistaBL();
        TransportistaBE objTransportistaBE = new TransportistaBE();

        public frmCrudTransportista02()
        {
            InitializeComponent();
        }
        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos...
                if (txtNombre.Text.Trim() == ""|| txtApellido.Text.Trim() == "")
                {
                    throw new Exception("El nombre y apellido es obligatorio");
                }

                //Si todo OK, cargamos las propiedades de la instancia objProductoBE
                objTransportistaBE.NomTra = txtNombre.Text.Trim();
                objTransportistaBE.ApeTra = txtApellido.Text.Trim();
                objTransportistaBE.DniTra = txtDni.Text.Trim();
                objTransportistaBE.TlfTra = txtTelefono.Text.Trim();
                objTransportistaBE.CrrTra = txtCorreo.Text.Trim();
                objTransportistaBE.DrcTra = txtDireccion.Text.Trim();
                objTransportistaBE.NroBrv = Convert.ToInt16(txtBrevete.Text.Trim());
                objTransportistaBE.FchIng = dtpIngreso.Value;
                objTransportistaBE.FcaBrv = dtpCaducidad.Value;


                objTransportistaBE.UsrReg = "jUnzueta";

                //Invocamos al metodo InsertarProducto...
                if (objTransportistaBL.InsertarTransportista(objTransportistaBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el registro, contacte con IT");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
