using ProyVillaze_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using ProyVillaze_BE;

namespace EParcial_RamosLing
{
    public partial class frmCrudCliente03 : Form
    {
        ClienteBL objClienteBL = new ClienteBL();
        ClienteBE objClienteBE = new ClienteBE();

        

        public frmCrudCliente03()
        {
            InitializeComponent();
        }

        public String Codigo { get; set; }

        private void frmCrudCliente03_Load(object sender, EventArgs e)
        {
           
            try
            {
                // Cargamos los combos...
                DataTable dt = objClienteBL.ListarCliente();
                DataRow dr; 

                // Mostramos los datos del producto actualizar...
                objClienteBE = objClienteBL.ConsultarCliente(this.Codigo);
                lblCodigo.Text = objClienteBE.IdClie;
                txtNombre.Text = objClienteBE.NoClie;
                txtApellido.Text = objClienteBE.ApClie;
                txtDni.Text = objClienteBE.DniCli;
                txtCorreo.Text = objClienteBE.CrrCli;
                txtDireccion.Text = objClienteBE.CliDir;
                txtTelefono.Text = objClienteBE.CliTlf.ToString();
                txtTelefonoContacto.Text = objClienteBE.ClTlfc.ToString();
                chkActivo.Checked = Convert.ToBoolean(objClienteBE.EstCli);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos...
                if (txtNombre.Text.Trim() == "")
                {
                    throw new Exception("El nombre es obligatorio");
                }



                //Si todo OK, cargamos las propiedades de la instancia objProductoBE
                objClienteBE.IdClie = lblCodigo.Text.Trim();
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
                if (objClienteBL.ActualizarCliente(objClienteBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se actualizó el registro, contacte con IT");
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                    || e.KeyChar == (char)Keys.Back);
        }

        private void txtTelefonoContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                    || e.KeyChar == (char)Keys.Back);
        }
    }
}
