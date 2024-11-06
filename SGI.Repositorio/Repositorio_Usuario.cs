using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Repositorio;

namespace SGI;

public class Repositorio_Usuario(GestorContext context) : IRepositorio<Usuario> 
{
    public void Agregar(Usuario usuario){
        if(!context.Usuarios.Any(u => u.Email == usuario.Email)){
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            if(usuario.Id==1){
                usuario.Permisos.Add(Permiso.AgregarCategoria);
                usuario.Permisos.Add(Permiso.CategoriaAlta);
                usuario.Permisos.Add(Permiso.CategoriaBaja);
                usuario.Permisos.Add(Permiso.CategoriaModificacion);
                usuario.Permisos.Add(Permiso.ProductoAlta);
                usuario.Permisos.Add(Permiso.ProductoBaja);
                usuario.Permisos.Add(Permiso.ProductoModificacion);
                usuario.Permisos.Add(Permiso.TransaccionAlta);
                usuario.Permisos.Add(Permiso.TransaccionBaja);
                usuario.Permisos.Add(Permiso.UsuarioAlta);
                usuario.Permisos.Add(Permiso.UsuarioBaja);
                usuario.Permisos.Add(Permiso.UsuarioModificacion);
                context.SaveChanges();
            }
        }else{
            throw new RepositoriosException("Existe un usuario con ese Email");
        }
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

    public void Modificar(Usuario modusuario){
        Usuario? usuario = ObtenerPorId(modusuario.Id);
        if(usuario != null){
            usuario.Nombre = modusuario.Nombre;
            usuario.Apellido = modusuario.Apellido;
            usuario.Email = modusuario.Email;
            modusuario.Contraseña = SistemaHashing.getHash(modusuario.Contraseña ?? " ");
            usuario.Contraseña = modusuario.Contraseña;
            usuario.Permisos = modusuario.Permisos;
            context.SaveChanges();
        }
    }

    public Usuario BuscarPorAtributo(string Email){
        return context.Usuarios.FirstOrDefault(u => u.Email == Email) ?? throw new RepositoriosException($"El usuario con email {Email} no fue encontrado");
    }

    public void EliminarEntAso(){}
}
