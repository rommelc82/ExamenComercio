using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaExamen
{
    public class daADO
    {
        public SqlConnection conexion()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Modelo"].ToString();
            cnn.Open();
            return cnn;
        }
        public DataTable dt(string spName, List<SqlParameter> listParameter)
        {
            try
            {
                using (SqlConnection cnn = conexion())
                {
                    using (SqlCommand cmd = new SqlCommand(spName, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (listParameter != null)
                        {
                            foreach (var item in listParameter)
                            {
                                cmd.Parameters.Add(item);
                            }
                        }

                        cmd.ExecuteNonQuery();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.Tables[0];
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string guardar(string spName, List<SqlParameter> listParameter)
        {
            try
            {
                using (SqlConnection cnn = conexion())
                {
                    using (SqlCommand cmd = new SqlCommand(spName, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (listParameter != null)
                        {
                            foreach (var item in listParameter)
                            {
                                cmd.Parameters.Add(item);
                            }
                        }
                        return (cmd.ExecuteScalar()).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(string spName, List<SqlParameter> listParameter)
        {
            try
            {
                using (SqlConnection cnn = conexion())
                {
                    using (SqlCommand cmd = new SqlCommand(spName, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (listParameter != null)
                        {
                            foreach (var item in listParameter)
                            {
                                cmd.Parameters.Add(item);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
