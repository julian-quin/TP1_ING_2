using Xunit;
using Negocio;

namespace Negocio.test;

public class Test_Producto
{

    // ----------------------------------------- PARTE DEL PUNTO 1 -------------------------------------------
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

    // ------------------------------------------------ FIN ----------------------------------------------------


    // ----------------------------------------- PARTE DEL PUNTO 2 --------------------------------------------
    
    [Fact]
    public void ActualizarPrecio_PrecioNegativo_LanzaException()
    {
        // -------------------------------------------------------------------------------
        // ARRANGE (Preparar): Instanciamos un producto válido.
        // -------------------------------------------------------------------------------
        Producto producto = new Producto("Yerba", 1000, Categoria.NoPerecedero);
        double precioInvalido = -500;

        // -------------------------------------------------------------------------------
        // ACT & ASSERT (Actuar y Verificar en conjunto):
        // Usamos Assert.Throws para capturar la excepción que se espera lanzar cuando se
        // invoca el método con un argumento fuera del rango válido (negativo).
        // -------------------------------------------------------------------------------
        var excepcionLanzada = Assert.Throws<ArgumentException>(() => producto.ActualizarPrecio(precioInvalido));

        // Verificación Adicional: Comprobamos que el mensaje de error de la excepción
        // contenga la explicación correspondiente.
        Assert.Equal("El precio no puede ser negativo.", excepcionLanzada.Message);
    }

    [Fact]
    public void ActualizarPrecio_PrecioValido_ActualizaElPrecioCorrectamente()
    {
        // -------------------------------------------------------------------------------
        // ARRANGE (Preparar): Creamos un producto inicial con precio de $1000.
        // -------------------------------------------------------------------------------
        Producto producto = new Producto("Yerba", 1000, Categoria.NoPerecedero);
        double nuevoPrecioValido = 1800;

        // -------------------------------------------------------------------------------
        // ACT (Actuar): Invocamos el método con un precio positivo legítimo.
        // -------------------------------------------------------------------------------
        producto.ActualizarPrecio(nuevoPrecioValido);

        // -------------------------------------------------------------------------------
        // ASSERT (Afirmar/Verificar): Confirmamos que el precio cambió exitosamente a $1800.
        // -------------------------------------------------------------------------------
        Assert.Equal(nuevoPrecioValido, producto.Precio);
    }

    // ------------------------------------------------ FIN ----------------------------------------------------
}