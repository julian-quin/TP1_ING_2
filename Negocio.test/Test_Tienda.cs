using Xunit;
using Negocio;
using Moq;
public class Test_Tienda
{


    // para escribir los metodos de prueba usamos el patron AAA (Arrange,Act,Assert)
    // estructura de nombre del metodo que prueban ( NombreDelMetodo_EscenarioAProbar_ResultadoEsperado )
   
    // -------------------------------------- PARTE DEL PUNTO 1 ------------------------------------------------------------ 

    //a. agregar producto al inventario
    [Fact]
    public void AgregarProducto_ProductoValido_SeGuardaCorrectamente()
    {
        // Arrange
        Tienda miTienda = new Tienda(); 
        Producto nuevoProducto = new Producto("Banana", 1500, Categoria.Verdura);

        // Act
        miTienda.AgregarProducto(nuevoProducto);
        var productoGuardado = miTienda.BuscarProducto("Banana");

        // Assert
        Assert.NotNull(productoGuardado); // verifico que productoGuardado al menos no sea null
        Assert.Equal("Banana", productoGuardado.Nombre); // chequeo que si se pasó la sentencia anterior, lo que se traiga sea el producto que acabo de agregar a la lista
    }
   
    // b. Buscar un producto por su nombre.
    [Fact]
    public void BuscarProducto_NombreCorrecto_RetornaProducto() 
    {
        // Arrange
        Tienda miTienda = new Tienda();
        Producto producto = new Producto("Banana", 1500,Categoria.Verdura);
        miTienda.AgregarProducto(producto); // Lo agregamos para poder buscarlo

        // Act
        var resultado = miTienda.BuscarProducto("Banana");

        // Assert
        Assert.NotNull(resultado); // Nos aseguramos de que la busqueda devolvió algo, es decir que la variable no sea nula
        Assert.Equal("Banana", resultado.Nombre); // Aseguramos que el producto traido sea el correcto, para que la prueba valide al 100%    
    }

    [Fact]
    public void BuscarProducto_NombreIncorrecto_RetornaNull() 
    {
        // Arrange
        Tienda miTienda = new Tienda(); // Tienda vacía

        miTienda.AgregarProducto(new Producto("Manzana", 1000, Categoria.Verdura));
        miTienda.AgregarProducto(new Producto("Pera", 1200, Categoria.Verdura));

        // Act
        var resultado = miTienda.BuscarProducto("Inexistente"); // deberia devolver null

        // Assert
        Assert.Null(resultado); // Como el producto "inexistente" no existe, el valor en "resultado" debe ser null para que la prueba valide
    }

    [Fact]
    public void EliminarProducto_ProductoExistente_RetornaTrue()
    {
        // Arrange
        Tienda miTienda = new Tienda();
        Producto productoReal = new Producto("Manzana", 1000, Categoria.Verdura);
        
        // Lo agregamos nosotros mismos a mano para que exista
        miTienda.AgregarProducto(productoReal); 

        // Act
        // Lo borramos
        bool resultado = miTienda.EliminarProducto("Manzana");
        
        // Lo buscamos para confirmar que ya no está
        var busquedaPosterior = miTienda.BuscarProducto("Manzana");

        // Assert
        Assert.True(resultado); // Si resultado queda en true nos confirma que lo pudo eliminar
        Assert.Null(busquedaPosterior); // Al buscarlo, ya nos tiene que dar nulo
    }

    [Fact]
    public void EliminarProducto_ProductoInexistente_RetornaFalse()
    {
        // Arrange
        Tienda miTienda = new Tienda(); 
        Producto producto1 = new Producto("Manzana", 1000, Categoria.Verdura);
        Producto producto2 = new Producto("Coca Cola", 1500, Categoria.Bebidas);
        miTienda.AgregarProducto(producto1); 
        miTienda.AgregarProducto(producto2); 
        
        // Act
        // Intentamos borrar algo que no existe
        bool resultado = miTienda.EliminarProducto("Manzanaa");

        // Assert
        Assert.False(resultado); // "resultado" debe ser false para que nos confirma que falló porque no estaba y así se valide la prueba
    }



    // -------------------------------------- FIN PARTE DEL PUNTO 1 ------------------------------------------------------------ 

    
    
    // -------------------------------------------- PUNTO 3 ------------------------------------------------------------ 
    
    [Fact]
    public void AplicarDescuento_CalculaCorrectamente_VerificaLlamadaActualizarPrecio()
    {
        // Arrange
        Tienda miTienda = new Tienda();
        var mockProducto = new Mock<Producto>(); // creo el objeto que se va a comportar como producto (simulamos)
        // Le programamos las respuestas fijas (Esto sería actuar como Stub)
        mockProducto.SetupGet(p => p.Nombre).Returns("Yerba");// cuando se consulte el nombre de este producto devolvera yerba
        mockProducto.SetupGet(p => p.Precio).Returns(1000);// cuando se consulte por precio devolvera 1000. El metodo Aplicardescuento() de tienda verá 1000
        // Agregamos el objeto simulado a la tienda 
        miTienda.AgregarProducto(mockProducto.Object); //mockProducto.Object es el Producto simulado.

       
       
        // Act

        // Le pedimos a la tienda que le aplique un 20% de descuento a la Yerba
        miTienda.AplicarDescuento("Yerba", 20); 
        //lugo de aplicar el descuento la variable precioFinal queda en 800 (ver logica del metodo en tienda).

        
        // Assert

        // con esto verfico que el metodo ActualizarPrecio() de la clase tienda se haya llamado una vez (por el objeto mockProducto) y que en dicho llamado dicho metodo haya recibido el valor 800 como parametro
        mockProducto.Verify(p => p.ActualizarPrecio(800), Times.Once);
    }
}