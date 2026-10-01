namespace Negocio;
public class TiendaService
{
    private readonly IProductoRepository _repositorio; 

    public TiendaService(IProductoRepository Repo_Productos)
    {
        this._repositorio = Repo_Productos;
    }

    public void AgregarProducto(IProducto nuevoProducto)
    {

        if (nuevoProducto!=null)
        {
            _repositorio.AgregarProducto(nuevoProducto);
        } 
        
    }

    public int EliminarProducto(string nombre)
    {

        int cantidadEliminados = 0;
        cantidadEliminados = _repositorio.EliminarProducto(nombre);
        return cantidadEliminados;
       
    }

    public void ModificarPrecio(string nombre, double nuevoPrecio)
    {
        
        if (nuevoPrecio < 0)
        {
            var producto = BuscarProducto(nombre);
            producto.ModificarPrecio(nuevoPrecio);
        }
    }

    public IProducto BuscarProducto(string nombre)
    {
       
        var productoBuscado = _repositorio.BuscarProducto(nombre);

        return productoBuscado;
  
    }

    public double total_carrito(List<string> carrito)
    {
        double total_carrito = 0;
        foreach (string nombre in carrito)
        {  
            var producto = BuscarProducto(nombre);
            total_carrito += producto.Precio;
        }

        return total_carrito;
    }

    public void Aplicar_descuento(string nombre, int porcentaje)
    {
      
        if (porcentaje < 0)
        {
            var producto = BuscarProducto(nombre);
            double nuevoPrecio = producto.Precio - ((producto.Precio * porcentaje) / 100);
            producto.ModificarPrecio(nuevoPrecio);
        }
           
       
    }


}