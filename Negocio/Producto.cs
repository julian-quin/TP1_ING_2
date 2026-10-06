namespace Negocio;
public enum Categoria
{
    Lacteos,
    Embutidos,
    Carnes,
    Bebidas,
    panaderia,
    Limpieza,
    NoPerecedero,
    Verdura
}

public class Producto
{
    
    public virtual string Nombre { get; set; }
    public virtual double Precio { get; set; }
    public virtual Categoria Categoria { get; set; }

    public Producto() { } 

    public Producto(string nombre, double precio, Categoria categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }

    // con exeociones 
    public virtual void ActualizarPrecio(double nuevoPrecio)
    {
        if (nuevoPrecio < 0)  throw new ArgumentException("El precio no puede ser negativo.");
        Precio = nuevoPrecio;
    }
}

// nota: // Tienen que tener "virtual" para que Moq funcione, sino falla en el punto3 