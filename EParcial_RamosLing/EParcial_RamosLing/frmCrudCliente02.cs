using ProyVillaze_BL;
using ProyVillze_BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EParcial_RamosLing
{
    public partial class frmCrudCliente02 : Form
    {

        ClienteBL objClienteBL = new ClienteBL();
        ClienteBE objClienteBE = new ClienteBE();
        

        public frmCrudCliente02()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos...
                if (txtNombre.Text.Trim() == "")
                {
                    throw new Exception("La descripcion es obligatoria");
                }



                //Si todo OK, cargamos las propiedades de la instancia objProductoBE
                objClienteBE.NoClie = txtNombre.Text.Trim();
                objClienteBE.ApClie = txtApellido.Text.Trim();
                objClienteBE.DniCli = txtDni.Text.Trim();
                objClienteBE.CrrCli = txtCorreo.Text.Trim();
                objClienteBE.CliDir = txtDireccion.Text.Trim();
                objClienteBE.CliTlf = Convert.ToInt16(txtTelefono.Text.Trim());
                objClienteBE.ClTlfc = Convert.ToInt16(txtTelefonoContacto.Text.Trim());
                objClienteBE.EstCli = Convert.ToInt16(chkActivo.Checked);



                objClienteBE.UsrReg = "aVillanueva";

                //Invocamos al metodo InsertarProducto...
                if (objClienteBL.InsertarCliente(objClienteBE) == true)
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
