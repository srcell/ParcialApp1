using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace EParcial_RamosLing
{
    internal class BaseDatos
    {
        private string cadenaConexion = "server = IRLING; Database=BD_VILLAZE;Integrated Security=true";

        public static string usuario = "";

        public void Iniciar(string IniUsu, string ConUsu)
        {
            usuario = "";

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlParameter parIniUsu = new SqlParameter("@IniUsu", IniUsu);
            SqlParameter parConUsu = new SqlParameter("@ConUsu", ConUsu);

            SqlCommand comando = new SqlCommand("select NivUsu, EstUsu FecReg, UsuReg From Tb_Usuarios Where IniUsu = '@IniUsu' AND ConUsu COLLATE Latin1_general_CS_AS = '@ConUsu'");
            comando.Parameters.Add(parIniUsu);
            comando.Parameters.Add(parConUsu);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                usuario = lector.GetString(0) + "" + lector.GetString(1) + lector.GetString(2);
                
            }

            lector.Close();
            conexion.Close();
        }
    }
}
