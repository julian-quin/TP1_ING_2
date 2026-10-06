namespace Negocio;
public class Tienda
{
    private List<Producto> _productos = new List<Producto>();

    public bool AgregarProducto(Producto nuevoProducto)
    {

        if (nuevoProducto!=null)
        {
            _productos.Add(nuevoProducto);
            return true;
        } 

        return false;
        
    }

     
    // -------------------------- BuscarProducto y EliminarProducto sin exepciones ------------------------------------------
   
   // nota : en realidad a estos habia que modificarlos, pero los dejé para no borrar las pruebas del apartado 1
   // agregué los mismos metodos abajo con el mismo nombre + una "E" para que se sepa que son los que manejan
   // exepciones. Lo hice asi solo con fines de aprender. Lo correcto seria modificarlos a estos directamente:
    public Producto BuscarProducto(string nombre)
    {
        var producto = _productos.FirstOrDefault(p => p.Nombre == nombre);
        return producto;
    }

    public bool EliminarProducto(string nombre)
    {
        var productoEncontrado = _productos.FirstOrDefault(p => p.Nombre == nombre);
        if (productoEncontrado != null)
        {
            _productos.Remove(productoEncontrado);
            return true;
        }

        return false;

    }


    //--------------------------- BuscarProducto y EliminarProducto con exepciones ----------------------------

    public Producto BuscarProductoE(string nombre)
    {
        var producto = _productos.FirstOrDefault(p => p.Nombre == nombre);
        
        if (producto == null) throw new InvalidOperationException("El producto no existe en el inventario.");
        
        return producto;
    }

    public bool EliminarProductoE(string nombre)
    {
        var productoEncontrado = _productos.FirstOrDefault(p => p.Nombre == nombre);
        
        if (productoEncontrado == null) throw new InvalidOperationException("No se puede eliminar porque el producto no existe.");
        _productos.Remove(productoEncontrado);
        return true;
    }

    //----------------------------------------------------------------------------------------------------------------------------
    public bool AplicarDescuento(string nombre, double porcentaje)
    {
        var producto = BuscarProducto(nombre);

        double descuento = producto.Precio * (porcentaje / 100);
        double precioFinal = producto.Precio - descuento;

        producto.ActualizarPrecio(precioFinal);

        return true;
    }

    public double CalcularTotalCarrito(List<string> carrito)
    {
        double total = 0;
        if (carrito == null) return 0;
        foreach (var nombreProducto in carrito)
        {
            var producto = BuscarProducto(nombreProducto);
            total += producto.Precio;
        }
        return total;
    }


}