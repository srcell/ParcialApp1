using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProyVillaze_BE
{
    public class TransportistaBE
    {
        public String IdTran { get; set; }
        public String NomTra { get; set; }
        public String ApeTra { get; set; }
        public String DniTra { get; set; }
        public String DrcTra { get; set; }
        public String TlfTra { get; set; }
        public String CrrTra { get; set; }
        public DateTime FchIng { get; set; }
        public Int16 NroBrv { get; set; }
        public DateTime FcaBrv { get; set; }
        public String UsrReg { get; set; }
        public DateTime FchReg { get; set; }
        public String UULtMod { get; set; }
        public String FULtMod { get; set; }
        public Blob FtTran { get; set; }

    }
}
