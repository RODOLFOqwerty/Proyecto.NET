using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Repositorio;

namespace SGI;

public class Repositorio_Usuario(GestorContext context) : IRepositorio<Usuario> 
{
    public void Agregar(Usuario usuario){
        context.Usuarios.Add(usuario);
        context.SaveChanges();
    }

    public void Eliminar(int id){
        Usuario? usuario = context.Usuarios.Find(id);
        if(usuario != null){
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }else{
            throw new RepositoriosException("EL USUARIO NO FUE ENCONTRADO");
        }
    }

    public Usuario ObtenerPorId(int id){
        Usuario? usuario = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if(usuario == null){
            throw new RepositoriosException("EL USUARIO NO FUE ENCONTRADO");
        }else{
            return usuario;
        }
    }

    public IEnumerable<Usuario> Listar(){
        return context.Usuarios.ToList() ?? new List<Usuario>();
    }
}
