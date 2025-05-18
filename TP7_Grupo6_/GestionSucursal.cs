using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP7_Grupo6_
{
    public class GestionSucursal
    {

        public void BuscarSucursal(SqlDataSource dataSource, string textoBuscar)
        {
            dataSource.SelectParameters.Clear();
            dataSource.SelectParameters.Add("nombre", textoBuscar);
            dataSource.SelectCommand = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal]" +
                " FROM [Sucursal] WHERE [NombreSucursal] LIKE '%' + (@nombre) + '%'";
        }

        public void MostrarSucursales(SqlDataSource dataSource)
        {
            dataSource.SelectCommand = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal]" +
                " FROM [Sucursal]";
        }
    }
}