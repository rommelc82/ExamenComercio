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
    public class daOrdenPago
    {
        daADO ado = new daADO();
        public List<ordenpago> list()
        {
            try
            {
                List<ordenpago> list = new List<ordenpago>();
                DataTable dt = ado.dt("sp_sel_ordenpago", null);
                foreach (DataRow item in dt.Rows)
                {
                    ordenpago _ordenpago = new ordenpago();
                    _ordenpago.id = Convert.ToInt32(item["id"]);
                    _ordenpago.monto = Convert.ToDecimal(item["monto"]);
                    _ordenpago.sucursal = new sucursal { nombre = item["sucursal"].ToString(), banco = new banco { nombre = item["banco"].ToString() } };
                    _ordenpago.moneda = item["moneda"].ToString();
                    _ordenpago.des_estado = item["des_estado"].ToString();

                    list.Add(_ordenpago);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ordenpago ordenpagoxId(int id)
        {
            try
            {
                List<ordenpago> list = new List<ordenpago>();
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@id";
                par.Value = id;
                listParametros.Add(par);
                DataTable dt = ado.dt("sp_sel_ordenpagoxid", listParametros);
                ordenpago eordenpago = new ordenpago();
                if (dt.Rows.Count == 1)
                {
                    eordenpago.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    eordenpago.sucursal = new sucursal { nombre = dt.Rows[0]["sucursal"].ToString(), banco = new banco { nombre = dt.Rows[0]["banco"].ToString() } };
                    eordenpago.monto = Convert.ToDecimal(dt.Rows[0]["monto"]);
                    eordenpago.moneda = dt.Rows[0]["moneda"].ToString();
                    eordenpago.estado = Convert.ToInt32(dt.Rows[0]["estado"]);
                }

                return eordenpago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ordenpagoGuardar(ordenpago eordenpago)
        {
            try
            {
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@monto";
                par.Value = eordenpago.monto;
                listParametros.Add(par);
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@moneda";
                par1.Value = eordenpago.moneda;
                listParametros.Add(par1);
                SqlParameter par2 = new SqlParameter();
                par2.ParameterName = "@estado";
                par2.Value = eordenpago.estado;
                listParametros.Add(par2);
                int id = 0;
                if (eordenpago.id != 0)
                {
                    SqlParameter par3 = new SqlParameter();
                    par3.ParameterName = "@id";
                    par3.Value = eordenpago.id;
                    listParametros.Add(par3);
                    ado.guardar("sp_upd_ordenpago", listParametros);
                }
                else
                {
                    SqlParameter par4 = new SqlParameter();
                    par4.ParameterName = "@idsucursal";
                    par4.Value = eordenpago.idsucursal;
                    listParametros.Add(par4);
                    id = Convert.ToInt32(ado.guardar("sp_ins_ordenpago", listParametros));
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
                ado.Eliminar("sp_del_ordenpago", listParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<detalleparametro> listEstadoOp()
        {
            try
            {
                List<detalleparametro> list = new List<detalleparametro>();
                DataTable dt = ado.dt("sp_sel_estadosop", null);
                foreach (DataRow item in dt.Rows)
                {
                    detalleparametro _detalleparametro = new detalleparametro();
                    _detalleparametro.id = Convert.ToInt32(item["id"]);
                    _detalleparametro.descripcion = item["descripcion"].ToString();

                    list.Add(_detalleparametro);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ordenpago> ordenpagoxSucursaMoneda(string sSucursal, string sMoneda )
        {
            try
            {
                List<ordenpago> list = new List<ordenpago>();
                List<SqlParameter> listParametros = new List<SqlParameter>();
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@sucursal";
                par.Value = sSucursal;
                listParametros.Add(par);
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@moneda";
                par1.Value = sMoneda;
                listParametros.Add(par1);
                DataTable dt = ado.dt("sp_sel_ordenpagoxsucursalxmoneda", listParametros);
                foreach (DataRow item in dt.Rows)
                {
                    ordenpago eordenpago = new ordenpago();
                    eordenpago.id = Convert.ToInt32(item["id"]);
                    eordenpago.sucursal = new sucursal { nombre = item["sucursal"].ToString(), banco = new banco { nombre = item["banco"].ToString() } };
                    eordenpago.monto = Convert.ToDecimal(item["monto"]);
                    eordenpago.moneda = item["moneda"].ToString();
                    eordenpago.des_estado = item["des_estado"].ToString();
                    list.Add(eordenpago);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
