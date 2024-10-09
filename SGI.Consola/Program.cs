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
            int e = Console.Read();
            switch(e){
                case 1: 
                    pruebas.PruebaTodoSaleBien();
                    Console.WriteLine("Se ejecuto");
                    break;
                case 2:
                    pruebas.Prueba2();
                    break;
                case 3:
                    pruebas.Prueba3();
                    break;
            }
            
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
                s+=" Producto:"+p.id+", nombre: "+p.nombre+". ";
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
