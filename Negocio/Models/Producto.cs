namespace Negocio;
public enum Categoria
{
    Lacteos,
    Embutidos,
    Carnes,
    Bebidas,
    panaderia,
    Limpieza,
    NoPerecedero
}
public class Producto: IProducto // firma el contrato
{
    private string nombre;
    private double precio;
    private Categoria categoria;

    public Producto(string nombre, double precio, Categoria categoria)// constructor
    {
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
    }
    public string Nombre { get => nombre;  }
    public double Precio { get => precio;  }
    public Categoria Categoria { get => categoria; }

    public void ModificarPrecio(double precio)
    {
        this.precio = precio;
    }
}


