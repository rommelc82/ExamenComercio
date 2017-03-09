using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWcfXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var identifica = txtBanco.Text.Trim() == "" ? "0" : txtBanco.Text.Trim();
            
            using (wsSucursales.SucursalesClient wsCliente = new wsSucursales.SucursalesClient())
            {
                var lista = wsCliente.list(Convert.ToInt32(identifica));
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("idbanco");
                dt.Columns.Add("banco");
                dt.Columns.Add("sucursal");
                dt.Columns.Add("direccion");

                foreach (var item in lista)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = item.id;
                    dr["idbanco"] = item.idbanco;
                    dr["banco"] = item.banco.nombre;
                    dr["sucursal"] = item.nombre;
                    dr["direccion"] = item.direccion;
                    dt.Rows.Add(dr);
                }
                dgvSucursales.DataSource = dt;

            }
        }
    }
}
