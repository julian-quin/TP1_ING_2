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
    public Producto BuscarProducto(string nombre)
    {
        return _productos.FirstOrDefault(p => p.Nombre == nombre);
    }

    public bool EliminarProducto(string nombre)
    {
        var productoEncontrado = BuscarProducto(nombre);
        if (productoEncontrado == null)
        {
            return false;
        }
        _productos.Remove(productoEncontrado);
        return true;
    }

    public bool AplicarDescuento(string nombre, double porcentaje)
    {
        var productoEncontrado = BuscarProducto(nombre);

        if (productoEncontrado == null)
        {
            return false;
        }

        double montoDescuento = productoEncontrado.Precio * (porcentaje / 100);
        productoEncontrado.Precio -= montoDescuento;

        return true;
    }

    public bool ModificarPrecio(string nombre, double nuevoPrecio)
    {
   
        if (nuevoPrecio > 0)
        {
            var productoEncontrado = BuscarProducto(nombre);

            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
                return true;
            }
        }   
        return false;
    }


}