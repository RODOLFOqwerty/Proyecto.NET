using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Repositorio;

namespace SGI;

public class Repositorio_Producto(GestorContext context): IRepositorio<Producto>
{
    //private readonly string _filePath = "Producto.txt";
    
    public void Agregar(Producto producto){
        context.Productos.Add(producto);
        context.SaveChanges();
    }


    public IEnumerable<Producto> Listar()  
    {
        return context.Productos.ToList() ?? new List<Producto>();
    }



    public void Eliminar(int id){
        Producto? producto = context.Productos.Where(p => p.id == id).SingleOrDefault();
        if(producto != null){
            context.Remove(producto);
            context.SaveChanges();
        }else{
            throw new Exception("EL PRODUCTO NO FUE ENCONTRADO");
        }
    }

    public Producto ObtenerPorId(int id)
    {
       Producto? producto = context.Productos.Where(p => p.id == id).SingleOrDefault();
        if(producto != null){
            return producto;
        }else{
            throw new Exception("EL PRODUCTO NO FUE ENCONTRADO");
        }
    }

}
