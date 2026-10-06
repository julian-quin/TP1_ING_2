using Negocio;
using Xunit;

public class TiendaFixture
{
    public Tienda CrearTiendaConProductos()
    {
        var tienda = new Tienda();

        tienda.AgregarProducto(
            new Producto("Manzana", 1000, Categoria.Verdura));

        tienda.AgregarProducto(
            new Producto("Pera", 1200, Categoria.Verdura));
        
        tienda.AgregarProducto(
            new Producto("Uva", 1100, Categoria.Verdura));
        
        tienda.AgregarProducto(
            new Producto("Lechuga", 500, Categoria.Verdura));
       
        tienda.AgregarProducto(
            new Producto("Torta de ojaldre", 10000, Categoria.panaderia));

        return tienda;
    }
}
