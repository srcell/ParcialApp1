using ProyVillaze_ADO;
using ProyVillaze_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar...

namespace ProyVillaze_BL
{
    public  class TransportistaBL
    {
        TransportistaADO objTransportistaADO = new TransportistaADO();

        public DataTable ListarTransportista()
        { 
           return objTransportistaADO.ListarTransportista();
        }
        public TransportistaBE ConsultarTransportista(String strCodigo)
        {
            return objTransportistaADO.ConsultarTransportista(strCodigo );
        }

        public Boolean InsertarTransportista(TransportistaBE objTransportistaBE)
        {
            return objTransportistaADO.InsertarTransportista(objTransportistaBE);
        }
        public Boolean ActualizarTransportista(TransportistaBE objTransportistaBE)
        {
            return objTransportistaADO.ActualizarTransportista(objTransportistaBE);
        }
        public Boolean EliminarTransportista(String strCodigo)
        {
            return objTransportistaADO.EliminarTransportista(strCodigo);
        }
    }
}
