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

    public void Modificar(Producto modproducto){
        Producto? producto = ObtenerPorId(modproducto.id);
        if(producto != null){
            producto.categoriaId = modproducto.categoriaId;
            producto.descripcion = modproducto.descripcion;
            producto.nombre = modproducto.nombre;
            producto.precioUnitario = modproducto.precioUnitario;
            producto.fechaUM = modproducto.fechaUM;
            context.SaveChanges();
        }
    }

}
