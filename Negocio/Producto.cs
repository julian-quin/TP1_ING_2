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
    // Constructor
    public Producto(string nombre, double precio, Categoria categoria)
    {
        Nombre = nombre;     // Asignación directa a la propiedad
        Precio = precio;     // Asignación directa a la propiedad
        Categoria = categoria; // Asignación directa a la propiedad
    }

    // Propiedades automáticas
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public Categoria Categoria { get; set; }
}
