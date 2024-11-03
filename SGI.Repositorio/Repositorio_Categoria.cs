using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion;
using System.Collections;
using SGI.Repositorio;

namespace SGI;

public class Repositorio_Categoria(GestorContext context) : IRepositorio<Categoria>
{
   
    public void Agregar(Categoria categoria)
    {
        context.Categorias.Add(categoria);
        context.SaveChanges();
    }

    public Categoria ObtenerPorId(int id)
    {
        Categoria? categoria = context.Categorias.Find(id) ?? null;
        if(categoria ==  null){
            throw new RepositoriosException("LA CATEGORIA NO FUE ENCONTRADA");
        }else{
            return categoria;
        }
    }

    public IEnumerable<Categoria> Listar()
    {
        return context.Categorias.ToList() ?? new List<Categoria>();
    }

    public void Eliminar(int id)
    {
        Categoria? categoria = context.Categorias.Find(id);
        if(categoria != null){
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }else{
            throw new RepositoriosException("LA CATEGORIA NO FUE ENCONTRADA");
        }

    }

    public void Modificar(Categoria modcategoria){
        Categoria? categoria = ObtenerPorId(modcategoria.id);
        if(categoria != null){
            categoria.descripcion = modcategoria.descripcion;
            categoria.nombre = modcategoria.nombre;
            categoria.fechaUM = DateTime.Now;
            context.SaveChanges();
        }
    }

}