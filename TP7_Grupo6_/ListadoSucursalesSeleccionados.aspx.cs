using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP7_Grupo6_
{
	public partial class ListadoSucursalesSeleccionados : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{ if  (Session["Tabla"] == null)
                {
					lblMensaje.Text = "No hay sucursales seleccionadas";
                }
                else
                {
					DataTable source = (DataTable)Session["Tabla"];
					gridviewSeleccionadas.DataSource = source;
					gridviewSeleccionadas.DataBind();
				}
				

			}
		}
	}
}