using Xunit;
using Negocio;

namespace Negocio.test;

public class Test_Producto
{

    // -------------------------- PARTE DEL PUNTO 1 -------------------------------
    [Fact]
    public void Constructor_ConDatosValidos_AsignaLasPropiedadesCorrectamente()
    {
        // Arrange
        string nombreEsperado = "Manzana";
        double precioEsperado = 1500;
        Categoria categoriaEsperada = Categoria.Verdura;

        // Act
        // Instanciamos el producto usando el constructor
        Producto producto = new Producto(nombreEsperado, precioEsperado, categoriaEsperada);

        // Assert
        // Verificamos que lo que le pasamos por parámetro realmente se haya guardado en sus propiedades
        Assert.Equal(nombreEsperado, producto.Nombre);
        Assert.Equal(precioEsperado, producto.Precio);
        Assert.Equal(categoriaEsperada, producto.Categoria);
    }

    [Fact]
    public void ModificarPropiedades_NuevosValores_SeActualizanCorrectamente()
    {
        // Arrange
        // Creamos un producto inicial
        Producto producto = new Producto("Yerba", 2000, Categoria.NoPerecedero);

        // Act
        // Utilizamos los "set" de las propiedades automáticas para cambiarle los datos
        producto.Nombre = "Yerba Mate Premium";
        producto.Precio = 2500;
        producto.Categoria = Categoria.Limpieza; // Un cambio arbitrario para probar que el enum cambia

        // Assert
        // Verificamos que la clase haya retenido los nuevos valores
        Assert.Equal("Yerba Mate Premium", producto.Nombre);
        Assert.Equal(2500, producto.Precio);
        Assert.Equal(Categoria.Limpieza, producto.Categoria);
    }
}