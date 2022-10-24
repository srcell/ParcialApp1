
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // Para los objetos DataTable, DataRow y DataView
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Agregar...
using ProyVillaze_BL;

namespace EParcial_RamosLing
{
    public partial class frmCrudTransportista : Form
    {
        // Instancias
        TransportistaBL objTransportistaBL = new TransportistaBL();
        DataView dtv;

        public frmCrudTransportista()
        {
            InitializeComponent();
        }

        private void frmCrudTransportista_Load(object sender, EventArgs e)
        {
         
            CargarDatos("");

        }

        private void CargarDatos(String strFiltro)
        {

            // Construimos  el objeto Dataview dtv  en base al DataTable devuelto por el metodo ListarProducto
            //  e invocamos al metodo CargarDatos pasandole una cadena vacia ,
            //  lo cual hara que se muestren todos los proveedores por defecto al momento de cargar el formulario

            dtv = new DataView(objTransportistaBL.ListarTransportista());
            dtv.RowFilter = "NomTra like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
            lblRegistros.Text = dtgDatos.Rows.Count.ToString();
            
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Pasaremos al metodo CargarDatos el texto que se va escribiendo
                // en la caja de texto 
                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmCrudTransportista02 objTran02 = new frmCrudTransportista02();
                objTran02.ShowDialog();

                
                CargarDatos(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmCrudTransportista03 objTran03 = new frmCrudTransportista03();
                
                objTran03.Codigo = dtgDatos.CurrentRow.Cells[0].Value.ToString();

               
                objTran03.ShowDialog();

                
                CargarDatos(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult vrpta;
                vrpta = MessageBox.Show("¿Seguro de eleminar el registro?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (vrpta == DialogResult.Yes)
                {
                    //  Invocamos el metodo eliminar...
                    if (objTransportistaBL.EliminarTransportista(dtgDatos.CurrentRow.Cells[0].Value.ToString()) == true)
                    {
                        //Refrescamos en el DataGrid...
                        CargarDatos(txtFiltro.Text);
                    }
                    else
                    {
                        throw new Exception("No se pudo eliminar porque el transportista estaba asociada a otra tabla");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
