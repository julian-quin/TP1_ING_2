# TRABAJO PRÁCTICO N 1 - INGENIERÍA DE SOFTWARE II

**Integrantes:**
- Falco, Luciano Sebastian
- Isasmendi, Javier Alfredo
- Quinteros, Julio Cesar - (usuario git: julian-quin, julianquinn18)



## Ejecución de Pruebas con Xunit

Este proyecto está desarrollado en **C#** y requiere el **SDK de .NET 10.0**. Es indispensable contar con esta versión instalada para garantizar la correcta compilación y evitar problemas de compatibilidad.

### Requisitos previos
- Tener instalado el SDK de .NET 10.0.
- Abrir una terminal (PowerShell, CMD o la terminal de tu editor de código).
- Posicionarse en el directorio raíz del proyecto (la carpeta principal de la solución).

### Comandos de ejecución

**Para ejecutar la suite completa de pruebas:**
Este comando buscará y ejecutará automáticamente todas las pruebas disponibles en el proyecto (tanto para `Producto` como para `Tienda`).

    dotnet test

**Para ejecutar las pruebas de una sola clase:**
Si deseas correr únicamente los tests correspondientes a una clase específica, puedes utilizar el atributo `--filter`. Por ejemplo, para ejecutar solo las pruebas de la clase `Test_Producto`, se utiliza el siguiente comando:

    dotnet test --filter FullyQualifiedName~Test_Producto

*(De la misma forma, para correr solo las pruebas de la tienda, utilizarías: `dotnet test --filter FullyQualifiedName~Test_Tienda`)*

### Resultados esperados
El framework ejecutará los métodos de prueba siguiendo el patrón **AAA (Arrange, Act, Assert)**. 

Si la ejecución es correcta, la consola mostrará un resumen en color **verde**. Esto confirmará que la lógica de negocio opera correctamente y que los escenarios de error esperados (las excepciones `InvalidOperationException` y `ArgumentException`) están siendo lanzados y capturados con éxito por los tests.