using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyVillaze_BL;

namespace EParcial_RamosLing
{
    public partial class frmCrudCliente : Form
    {
        ClienteBL objClienteBL = new ClienteBL();
        DataView dtv;

        public frmCrudCliente()
        {
            InitializeComponent();
        }

        

        private void CargarDatos(String strFiltro)
        {

            // Construimos  el objeto Dataview dtv  en base al DataTable devuelto por el metodo ListarProducto
            //  e invocamos al metodo CargarDatos pasandole una cadena vacia ,
            //  lo cual hara que se muestren todos los proveedores por defecto al momento de cargar el formulario

            dtv = new DataView(objClienteBL.ListarCliente());
            dtv.RowFilter = "noclie like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
            lblRegistros.Text = dtgDatos.Rows.Count.ToString();

        }

        private void frmCrudCliente_Load(object sender, EventArgs e)
        {
            CargarDatos("");
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
                // Mostramos el formulario ProductoMan02...
                frmCrudCliente02 objCli02 = new frmCrudCliente02();
                objCli02.ShowDialog();// Modal...

                // Al terminar el proceso de insercion....
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
                // Manejamos la instancia del ProductoMan03...
                frmCrudCliente03 objCli03 = new frmCrudCliente03();
                //Obtenemos de la fila seleccionada en el Datagrid la celda 0 (cod_pro)
                objCli03.Codigo = dtgDatos.CurrentRow.Cells[0].Value.ToString();

                //Mostramos el formulario en forma modal...
                objCli03.ShowDialog();

                //Al terminar, refrescamos del DataGrid...
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
                    if (objClienteBL.EliminarCliente(dtgDatos.CurrentRow.Cells[0].Value.ToString()) == true)
                    {
                        //Refrescamos en el DataGrid...
                        CargarDatos(txtFiltro.Text);
                    }
                    else
                    {
                        throw new Exception("No se pudo eliminar porque el cliente estaba asociada a otra tabla");
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
