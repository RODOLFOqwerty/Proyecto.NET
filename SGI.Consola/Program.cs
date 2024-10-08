using SGI.Aplicacion.CasosdeUso;
using SGI.Aplicacion.Validaciones;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion;


namespace SGI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba
            var repositorioProducto = new Repositorio_Producto();
            var validadorProducto = new ProductoValidacion();
            var servicioAutorizacion = new ServicioAutorizacion();
            
            var casoUsoAltaProducto = new CasoUsoAltaProducto(repositorioProducto, validadorProducto, servicioAutorizacion);


            var nuevoProducto = new Producto
            {
                nombre = "Producto Ejemplo xd",
                descripcion = "Descripción del producto",
                precioUnitario = 10.0f,
                stock = 100,
                fechaC = DateTime.Now,
                fechaUM = DateTime.Now,
                categoriaId = 1
            };

            var usuario = new Usuario { Id = 1 };
            usuario.agregarTodosPermisos();
            try
            {
                casoUsoAltaProducto.Ejecutar(nuevoProducto, usuario);
                Console.WriteLine("Producto agregado de manera exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
