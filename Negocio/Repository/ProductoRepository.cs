namespace Negocio;

//clase que firma el contrato aca se encuentra todo el codigo que consulta a la DB
// en este caso no hay DB y solo mantenemos todo en memoria
public class ProductoRepository : IProductoRepository
{
    private List<IProducto> productos; // para mantener en memoria
    public ProductoRepository() //constructor
    {
        productos = new List<IProducto>
        {
            new Producto("Leche de soja",1800,Categoria.Lacteos),
            new Producto("Crema de leche",900,Categoria.Lacteos),
            new Producto("Queso",7000,Categoria.Embutidos),
            new Producto("Fideo largo lucchetti",1000,Categoria.NoPerecedero),
            new Producto("zapallo",1500,Categoria.Verdura),
            new Producto("Coca cola",1800,Categoria.Bebidas),
            new Producto("Pepsi",1800,Categoria.Bebidas),
            new Producto("Mortadela paladini",12000,Categoria.Embutidos),
            new Producto("Banana",1000,Categoria.NoPerecedero),
        };
    }

    public List<IProducto> obtenerProductos()
    {
        return productos;
    }

    public IProducto BuscarProducto(string nombre)
    {
        return productos.Find(p => p.Nombre == nombre);
    }

    public int EliminarProducto(string nombre)
    {
        var producto = BuscarProducto(nombre);

        if (producto == null) return 0;

        productos.Remove(producto);

        return 1;
    }

    public void AgregarProducto(IProducto producto)
    {
        productos.Add(producto);
    }





}