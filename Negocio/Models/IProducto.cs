namespace Negocio;
public interface IProducto // clase que define el contrato
{
    string Nombre {get;}
    double Precio {get;}
    Categoria Categoria {get;}
    void ModificarPrecio(double precio);
}


