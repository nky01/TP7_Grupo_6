using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_Grupo6_
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if(Session["FiltroProvincia"] != null)
                {
                    int idProvincia = (int)Session["FiltroProvincia"];
                    GestionSucursal gestion = new GestionSucursal();
                    gestion.buscarSucursalPorProvincia(SqlDataSource1, idProvincia);
                }
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ListViewItem item = (ListViewItem)btn.NamingContainer;

            string idSucursal = ((Label)item.FindControl("Id_SucursalLabel")).Text;
            string nombre = ((Label)item.FindControl("NombreSucursalLabel")).Text;
            string descripcion = ((Label)item.FindControl("DescripcionSucursalLabel")).Text;

            Session["ID_SUCURSAL"] = idSucursal;
            Session["NOMBRE"] = nombre;
            Session["DESCRIPCION"] = descripcion;

            lblMensaje.Text = "Sucursal seleccionada: ID: " + idSucursal + ", Nombre: " + nombre + ", Descripcion: " + descripcion;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["FiltroProvincia"] = null;
            GestionSucursal gestion = new GestionSucursal();
            if(txtBoxBuscar.Text.Trim() == string.Empty)
            {
                gestion.MostrarSucursales(SqlDataSource1);
                ListView1.DataBind();
                return;
            }
            gestion.BuscarSucursal(SqlDataSource1, txtBoxBuscar.Text);
            ListView1.DataBind();
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "filtradoPorProvincia")
            {
                if(int.TryParse(e.CommandArgument.ToString(),out int idProvincia))
                {
                    GestionSucursal gestion = new GestionSucursal();
                    gestion.buscarSucursalPorProvincia(SqlDataSource1, idProvincia);
                    ListView1.DataBind();
                    Session["FiltroProvincia"] = idProvincia;

                }

            }
        }
    }
}