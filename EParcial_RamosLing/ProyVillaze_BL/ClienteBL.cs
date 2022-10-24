using ProyVillaze_ADO;
using ProyVillze_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar...

namespace ProyVillaze_BL
{
    public  class ClienteBL
    {
        ClienteADO objClienteADO = new ClienteADO();

        public DataTable ListarCliente()
        { 
           return objClienteADO.ListarCliente();
        }
        public ClienteBE ConsultarCliente(String strCodigo)
        {
            return objClienteADO.ConsultarCliente (strCodigo );
        }

        public Boolean InsertarCliente(ClienteBE objProductoBE)
        {
            return objClienteADO.InsertarCliente(objProductoBE);
        }
        public Boolean ActualizarCliente(ClienteBE objProductoBE)
        {
            return objClienteADO.ActualizarCliente(objProductoBE);
        }
        public Boolean EliminarCliente(String strCodigo)
        {
            return objClienteADO.EliminarCliente(strCodigo);
        }
    }
}
