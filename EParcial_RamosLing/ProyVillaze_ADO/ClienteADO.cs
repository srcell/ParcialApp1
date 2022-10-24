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
    public  class ClienteADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarCliente()
        {

            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Listar_Clientes";
                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Clientes");
                return dts.Tables["Clientes"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ClienteBE ConsultarCliente(String strCodigo)
        {

            try
            {
                //Creamos la instancia de ProductoBE...
                ClienteBE objClienteBE = new ClienteBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Consultar_Clientes";
                //Manejamos parametros..
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdClie", strCodigo);

                //Abrimos y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objClienteBE.IdClie = dtr["IdClie"].ToString();
                    objClienteBE.NoClie = dtr["NoClie"].ToString();
                    objClienteBE.ApClie = dtr["ApClie"].ToString();
                    objClienteBE.DniCli = dtr["DniCli"].ToString();
                    objClienteBE.CrrCli = dtr["CrrCli"].ToString();
                    objClienteBE.CliDir = dtr["CliDir"].ToString();
                    objClienteBE.CliTlf = Convert.ToInt16(dtr["CliTlf"]);
                    objClienteBE.ClTlfc = Convert.ToInt16(dtr["ClTlfc"]);
                    objClienteBE.EstCli = Convert.ToInt16(dtr["EstCli"]);
                }
                dtr.Close();
                return objClienteBE;

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

        public Boolean InsertarCliente(ClienteBE objClienteBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Insertar_Clientes";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NoClie", objClienteBE.NoClie);
                cmd.Parameters.AddWithValue("@ApClie", objClienteBE.ApClie);
                cmd.Parameters.AddWithValue("@DniCli", objClienteBE.DniCli);
                cmd.Parameters.AddWithValue("@CrrCli", objClienteBE.CrrCli);
                cmd.Parameters.AddWithValue("@CliDir", objClienteBE.CliDir);
                cmd.Parameters.AddWithValue("@CliTlf", objClienteBE.CliTlf);
                cmd.Parameters.AddWithValue("@ClTlfc", objClienteBE.ClTlfc);
                cmd.Parameters.AddWithValue("@EstCli", objClienteBE.EstCli);
                cmd.Parameters.AddWithValue("@UsrReg", objClienteBE.UsrReg);
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
        public Boolean ActualizarCliente(ClienteBE objClienteBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Actualizar_Clientes";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdClie", objClienteBE.IdClie);
                cmd.Parameters.AddWithValue("@NoClie", objClienteBE.NoClie);
                cmd.Parameters.AddWithValue("@ApClie", objClienteBE.ApClie);
                cmd.Parameters.AddWithValue("@DniCli", objClienteBE.DniCli);
                cmd.Parameters.AddWithValue("@CrrCli", objClienteBE.CrrCli);
                cmd.Parameters.AddWithValue("@CliDir", objClienteBE.CliDir);
                cmd.Parameters.AddWithValue("@CliTlf", objClienteBE.CliTlf);
                cmd.Parameters.AddWithValue("@ClTlfc", objClienteBE.ClTlfc);
                cmd.Parameters.AddWithValue("@EstCli", objClienteBE.EstCli);
                cmd.Parameters.AddWithValue("@UsrReg", objClienteBE.UsrReg);
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

        public Boolean EliminarCliente(String strCodigo)
        {


            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Eliminar_Clientes";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdClie", strCodigo);
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
