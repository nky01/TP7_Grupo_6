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

        public void buscarSucursalPorProvincia(SqlDataSource dataSource, int provinciaAbuscar)
        {
            dataSource.SelectParameters.Clear();
            dataSource.SelectParameters.Add("provincia", provinciaAbuscar.ToString());
            dataSource.SelectCommand = "SELECT s.Id_Sucursal, s.NombreSucursal, s.DescripcionSucursal, s.URL_Imagen_Sucursal" +
                " from Sucursal s inner join Provincia p on s.Id_ProvinciaSucursal = p.Id_Provincia where p.Id_Provincia = @provincia";
        }
    }
}