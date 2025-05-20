using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP7_Grupo6_
{
	public class GestionSession
	{

        public DataTable CrearTabla()
        {
            DataTable dataTable = new DataTable();
            DataColumn dataColumn = new DataColumn("ID_SUCURSAL", System.Type.GetType("System.Int32"));
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("DESCRIPCION", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);
            return dataTable;
        }

        public DataTable AgregarFila(DataTable data, string id, string nombre, string descripcion)
        {
            DataRow row = data.NewRow();
            row["ID_SUCURSAL"] = int.Parse(id);
            row["NOMBRE"] = nombre;
            row["DESCRIPCION"] = descripcion;
            data.Rows.Add(row);
            return data;
        }

    }

}