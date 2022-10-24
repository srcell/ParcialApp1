using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyVillaze_BE;

namespace ProyVillaze_ADO
{
    public  class TransportistaADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarTransportista()
        {

            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Listar_transportistas";
                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Transportista");
                return dts.Tables["Transportista"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public TransportistaBE ConsultarTransportista(String strCodigo)
        {

            try
            {
                //Creamos la instancia de TransportistaBE...
                TransportistaBE objTransportistaBE = new TransportistaBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Consultar_transportistas";
                //Manejamos parametros..
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdTran", strCodigo);

                //Abrimos y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objTransportistaBE.IdTran = dtr["IdTran"].ToString();
                    objTransportistaBE.NomTra = dtr["NomTra"].ToString();
                    objTransportistaBE.ApeTra = dtr["ApeTran"].ToString();
                    objTransportistaBE.DniTra = dtr["DniTra"].ToString();
                    objTransportistaBE.DrcTra = dtr["DrcTra"].ToString();
                    objTransportistaBE.TlfTra = dtr["TlfTra"].ToString();
                    objTransportistaBE.CrrTra = dtr["CrrTra"].ToString();
                    objTransportistaBE.NroBrv = Convert.ToInt16(dtr["NroBrv"]);
                    objTransportistaBE.UsrReg = dtr["UsrReg"].ToString();
                }
                dtr.Close();
                return objTransportistaBE;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }

        public Boolean InsertarTransportista(TransportistaBE objTransportistaBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Insertar_Transportista";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NomTra", objTransportistaBE.NomTra);
                cmd.Parameters.AddWithValue("@ApeTra", objTransportistaBE.ApeTra);
                cmd.Parameters.AddWithValue("@DniTra", objTransportistaBE.DniTra);
                cmd.Parameters.AddWithValue("@DrcTra", objTransportistaBE.DrcTra);
                cmd.Parameters.AddWithValue("@TlfTra", objTransportistaBE.TlfTra);
                cmd.Parameters.AddWithValue("@CrrTra", objTransportistaBE.CrrTra);
                cmd.Parameters.AddWithValue("@NroBrv", objTransportistaBE.NroBrv);
                cmd.Parameters.AddWithValue("@UsrReg", objTransportistaBE.UsrReg);
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
        public Boolean ActualizarTransportista(TransportistaBE objTransportistaBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Actualizar_Transportistas";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdTran", objTransportistaBE.IdTran);
                cmd.Parameters.AddWithValue("@NomTra", objTransportistaBE.NomTra);
                cmd.Parameters.AddWithValue("@ApeTra", objTransportistaBE.ApeTra);
                cmd.Parameters.AddWithValue("@DniTra", objTransportistaBE.DniTra);
                cmd.Parameters.AddWithValue("@DrcTra", objTransportistaBE.DrcTra);
                cmd.Parameters.AddWithValue("@TlfTra", objTransportistaBE.TlfTra);
                cmd.Parameters.AddWithValue("@CrrTra", objTransportistaBE.CrrTra);
                cmd.Parameters.AddWithValue("@NroBrv", objTransportistaBE.NroBrv);
                cmd.Parameters.AddWithValue("@UUltMod", objTransportistaBE.UULtMod);
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }

        public Boolean EliminarTransportista(String strCodigo)
        {


            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Eliminar_Transportistas";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdTran", strCodigo);
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }
    }
}
