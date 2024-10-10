using SGI.Aplicacion.CasosdeUso;
using SGI.Aplicacion.Validaciones;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion;
using SGI;
using SGI.Aplicacion.Interfaces;

namespace SGI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Pruebas pruebas = new Pruebas();
            var repositorioProducto = new Repositorio_Producto();
            var repositorioCategoria = new Repositorio_Categoria();
            var repositorioTransaccion = new Repositorio_Transaccion();

            
            
            var casoUsoAltaProducto = new CasoUsoAltaProducto(repositorioProducto);
            var casoUsoAltaCategoria = new CasoUsoAltaCategoria(repositorioCategoria);
            var casoUsoAltaTransaccion = new CasoUsoAltaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoBajaCategoria = new CasoUsoBajaCategoria(repositorioCategoria,repositorioProducto);
            var casoUsoBajaProducto = new CasoUsoBajaProducto(repositorioProducto,repositorioTransaccion);
            var casoUsoBajaTransaccion = new CasoUsoBajaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoModificarCategoria = new CasoUsoModificarCategoria(repositorioCategoria);
            var casoUsoModificarProducto = new CasoUsoModificarProducto(repositorioProducto);

            var usuario = new Usuario { Id = 1 };
            usuario.agregarTodosPermisos();
            /*
                Se da de alta un producto Peperoni(Si el repositorio esta vacio su ID sera 1 caso contrario el id mas alto mas 1)
                Se da de alta una categoria Pizza(Si el repositorio esta vacio su ID sera 1 caso contrario el id mas alto mas 1)
            */
            casoUsoAltaCategoria.Ejecutar(new Categoria("Pizza","Comida de italia"),usuario);
            casoUsoAltaProducto.Ejecutar(new Producto("Peperoni","Comida con peperoni",10.0f,10,1),usuario);
            Console.WriteLine("PRODUCTOS: ");
            Console.WriteLine(pruebas.ImprimirProductos(repositorioProducto));
            //Se da de alta una transaccion de Entrada donde al producto con id 1 se le suma 5 al stock
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,5,TipoTransaccion.Entrada),usuario);
            
            Console.WriteLine(pruebas.ImprimirProductos(repositorioProducto));
            //Se da de alta una transaccion de Salida donde al producto con id 1 se le resta 5 al stock
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,5,TipoTransaccion.Salida),usuario);
            
            Console.WriteLine(pruebas.ImprimirProductos(repositorioProducto));
            Console.WriteLine("TRANSACCIONES: ");
            Console.WriteLine(pruebas.ImprimirTransacciones(repositorioTransaccion));
            //Se da de baja la transaccion con id 1
            casoUsoBajaTransaccion.Ejecutar(1,usuario);
            
            Console.WriteLine(pruebas.ImprimirProductos(repositorioProducto));
            //Se da de baja la transaccion con id 2
            casoUsoBajaTransaccion.Ejecutar(2,usuario);
            
            Console.WriteLine(pruebas.ImprimirProductos(repositorioProducto));     
        }

        
    }

    public class Pruebas{
        public void PruebaTodoSaleBien(){
            var repositorioProducto = new Repositorio_Producto();
            var repositorioCategoria = new Repositorio_Categoria();
            var repositorioTransaccion = new Repositorio_Transaccion();

            
            
            var casoUsoAltaProducto = new CasoUsoAltaProducto(repositorioProducto);
            var casoUsoAltaCategoria = new CasoUsoAltaCategoria(repositorioCategoria);
            var casoUsoAltaTransaccion = new CasoUsoAltaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoBajaCategoria = new CasoUsoBajaCategoria(repositorioCategoria,repositorioProducto);
            var casoUsoBajaProducto = new CasoUsoBajaProducto(repositorioProducto,repositorioTransaccion);
            var casoUsoBajaTransaccion = new CasoUsoBajaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoModificarCategoria = new CasoUsoModificarCategoria(repositorioCategoria);
            var casoUsoModificarProducto = new CasoUsoModificarProducto(repositorioProducto);

            var usuario = new Usuario { Id = 1 };
            usuario.agregarTodosPermisos();
            
            casoUsoAltaCategoria.Ejecutar(new Categoria("Frutas","Todo alimento fibroso"),usuario);
            casoUsoAltaProducto.Ejecutar(new Producto("Banana","Es algo amarillo",10.0f,10,1),usuario);
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,10,TipoTransaccion.Entrada),usuario);
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,10,TipoTransaccion.Salida),usuario);

            casoUsoModificarCategoria.Ejecutar(repositorioCategoria.ObtenerPorId(1),usuario);
            casoUsoModificarProducto.Ejecutar(repositorioProducto.ObtenerPorId(1),usuario);

            casoUsoAltaProducto.Ejecutar(new Producto("Frutilla","Descripcion generica",20.0f,10,1),usuario);
            casoUsoBajaTransaccion.Ejecutar(1,usuario);
            casoUsoBajaTransaccion.Ejecutar(2, usuario);
            casoUsoBajaProducto.Ejecutar(1,usuario);
            casoUsoBajaProducto.Ejecutar(2,usuario);
            casoUsoBajaCategoria.Ejecutar(1,usuario);  
        }

        public void Prueba2(){
            var repositorioProducto = new Repositorio_Producto();
            var repositorioCategoria = new Repositorio_Categoria();
            var repositorioTransaccion = new Repositorio_Transaccion();

            
            
            var casoUsoAltaProducto = new CasoUsoAltaProducto(repositorioProducto);
            var casoUsoAltaCategoria = new CasoUsoAltaCategoria(repositorioCategoria);
            var casoUsoAltaTransaccion = new CasoUsoAltaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoBajaCategoria = new CasoUsoBajaCategoria(repositorioCategoria,repositorioProducto);
            var casoUsoBajaProducto = new CasoUsoBajaProducto(repositorioProducto,repositorioTransaccion);
            var casoUsoBajaTransaccion = new CasoUsoBajaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoModificarCategoria = new CasoUsoModificarCategoria(repositorioCategoria);
            var casoUsoModificarProducto = new CasoUsoModificarProducto(repositorioProducto);

            var usuario = new Usuario { Id = 1 };
            usuario.agregarTodosPermisos();

            casoUsoAltaCategoria.Ejecutar(new Categoria("Carnes","Comida de carne"),usuario);
            casoUsoAltaProducto.Ejecutar(new Producto("Pechuga de pollo","generico de pollo",10.0f,10,1),usuario);
            casoUsoBajaCategoria.Ejecutar(1,usuario);
        }

        public string ImprimirProductos(IRepositorio<Producto> repositorio){
            string s="";
            foreach(Producto p in repositorio.Listar()){
                s+=" Producto:"+p.id+", nombre: "+p.nombre+", cantidad:"+p.stock+". ";
            }
            return s;
        }
        public string ImprimirCategorias(IRepositorio<Categoria> repositorio){
            string s="";
            foreach(Categoria c in repositorio.Listar()){
                s+=" Producto:"+c.id+", nombre: "+c.nombre+". ";
            }
            return s;
        }
        public string ImprimirTransacciones(IRepositorio<Transaccion> repositorio){
            string s="";
            foreach(Transaccion t in repositorio.Listar()){
                s+=" Producto:"+t.id+", prudcto asociado: "+t.productoid+" ";
            }
            return s;
        }
        public void Prueba3(){
            var repositorioProducto = new Repositorio_Producto();
            var repositorioCategoria = new Repositorio_Categoria();
            var repositorioTransaccion = new Repositorio_Transaccion();

            
            
            var casoUsoAltaProducto = new CasoUsoAltaProducto(repositorioProducto);
            var casoUsoAltaCategoria = new CasoUsoAltaCategoria(repositorioCategoria);
            var casoUsoAltaTransaccion = new CasoUsoAltaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoBajaCategoria = new CasoUsoBajaCategoria(repositorioCategoria,repositorioProducto);
            var casoUsoBajaProducto = new CasoUsoBajaProducto(repositorioProducto,repositorioTransaccion);
            var casoUsoBajaTransaccion = new CasoUsoBajaTransaccion(repositorioTransaccion,repositorioProducto);
            var casoUsoModificarCategoria = new CasoUsoModificarCategoria(repositorioCategoria);
            var casoUsoModificarProducto = new CasoUsoModificarProducto(repositorioProducto);

            var usuario = new Usuario { Id = 1 };
            usuario.agregarTodosPermisos();

            casoUsoAltaCategoria.Ejecutar(new Categoria("Pizza","Comida de italia"),usuario);
            casoUsoAltaProducto.Ejecutar(new Producto("Peperoni","Comida con peperoni",10.0f,10,1),usuario);
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,5,TipoTransaccion.Entrada),usuario);
            Console.WriteLine(ImprimirProductos(repositorioProducto));
            casoUsoAltaTransaccion.Ejecutar(new Transaccion(1,5,TipoTransaccion.Salida),usuario);
            Console.WriteLine(ImprimirProductos(repositorioProducto));
            casoUsoBajaTransaccion.Ejecutar(1,usuario);
            Console.WriteLine(ImprimirProductos(repositorioProducto));
            casoUsoBajaTransaccion.Ejecutar(2,usuario);
            Console.WriteLine(ImprimirProductos(repositorioProducto));
        }
    }
}
