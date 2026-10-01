namespace Negocio;
//escondemos todo el código complicado que habla con la base de datos, para que el resto de tu sistema se mantenga limpio y no tenga que lidiar con eso.
public interface IProductoRepository
{
    List<IProducto> obtenerProductos();
    void AgregarProducto(IProducto producto);
    int EliminarProducto(string nombre);
    IProducto BuscarProducto(string nombre);
}
