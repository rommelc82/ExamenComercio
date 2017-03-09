using BeExamen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaExamen
{
    public class daBanco
    {
        daADO ado = new daADO();
        public List<banco> list()
        {
            try
            {
                List<banco> list = new List<banco>();
                DataTable dt = ado.dt("sp_sel_banco", null);
                foreach (DataRow item in dt.Rows)
                {
                    banco _banco = new banco();
                    _banco.id = Convert.ToInt32(item["id"]);
                    _banco.nombre = item["nombre"].ToString();
                    _banco.direccion = item["direccion"].ToString();

                    list.Add(_banco);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public banco bancoxId(int id)
        {
            try
            {
                List<banco> list = new List<banco>();
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@id";
                par.Value = id;
                listParametros.Add(par);
                DataTable dt = ado.dt("sp_sel_bancoxid", listParametros);
                banco ebanco = new banco();
                if (dt.Rows.Count == 1)
                {
                    ebanco.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    ebanco.nombre = dt.Rows[0]["nombre"].ToString();
                    ebanco.direccion = dt.Rows[0]["direccion"].ToString();
                }

                return ebanco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int bancoGuardar(banco ebanco)
        {
            try
            {
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@nombre";
                par.Value = ebanco.nombre;
                listParametros.Add(par);
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@direccion";
                par1.Value = ebanco.direccion;
                listParametros.Add(par1);
                int id = 0;
                if (ebanco.id != 0)
                {
                    SqlParameter par2 = new SqlParameter();
                    par2.ParameterName = "@id";
                    par2.Value = ebanco.id;
                    listParametros.Add(par2);
                    ado.guardar("sp_upd_banco", listParametros);
                }
                else
                {
                    id = Convert.ToInt32(ado.guardar("sp_ins_banco", listParametros));
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();

                par.ParameterName = "@id";
                par.Value = id;
                listParametros.Add(par);
                ado.Eliminar("sp_del_banco", listParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
