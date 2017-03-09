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
    public class daSucursal
    {
        daADO ado = new daADO();
        public List<sucursal> list(int? idbanco)
        {
            try
            {
                List<sucursal> list = new List<sucursal>();
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@idbanco";
                par.Value = idbanco;
                listParametros.Add(par);
                DataTable dt = ado.dt("sp_sel_sucursal", listParametros);
                foreach (DataRow item in dt.Rows)
                {
                    sucursal _Sucursal = new sucursal();
                    _Sucursal.id = Convert.ToInt32(item["id"]);
                    _Sucursal.nombre = item["nombre"].ToString();
                    _Sucursal.idbanco = Convert.ToInt32(item["idbanco"]);
                    _Sucursal.banco = new banco { nombre = item["banco"].ToString() };
                    _Sucursal.direccion = item["direccion"].ToString();

                    list.Add(_Sucursal);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sucursal SucursalxId(int id)
        {
            try
            {
                List<sucursal> list = new List<sucursal>();
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@id";
                par.Value = id;
                listParametros.Add(par);
                DataTable dt = ado.dt("sp_sel_sucursalxid", listParametros);
                sucursal eSucursal = new sucursal();
                if (dt.Rows.Count == 1)
                {
                    eSucursal.id = Convert.ToInt32(dt.Rows[0]["id"]);

                    eSucursal.nombre = dt.Rows[0]["nombre"].ToString();
                    eSucursal.banco = new banco { nombre = dt.Rows[0]["banco"].ToString() };
                    eSucursal.direccion = dt.Rows[0]["direccion"].ToString();
                }

                return eSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SucursalGuardar(sucursal eSucursal)
        {
            try
            {
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@nombre";
                par.Value = eSucursal.nombre;
                listParametros.Add(par);
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@direccion";
                par1.Value = eSucursal.direccion;
                listParametros.Add(par1);
                int id = 0;
                if (eSucursal.id != 0)
                {
                    SqlParameter par2 = new SqlParameter();
                    par2.ParameterName = "@id";
                    par2.Value = eSucursal.id;
                    listParametros.Add(par2);
                    ado.guardar("sp_upd_sucursal", listParametros);
                }
                else
                {
                    SqlParameter par3 = new SqlParameter();
                    par3.ParameterName = "@idbanco";
                    par3.Value = eSucursal.idbanco;
                    listParametros.Add(par3);
                    id = Convert.ToInt32(ado.guardar("sp_ins_sucursal", listParametros));
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
                ado.Eliminar("sp_del_sucursal", listParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
