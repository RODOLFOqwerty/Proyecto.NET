using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class CasoUsoBajaUsuario(IRepositorio<Usuario> _repositorio, IServicioAutorizacion _servicioautorizacion)
{
    public void Ejecutar(Usuario usuario, Usuario usuariobaja){
        try{
            if(_servicioautorizacion.PoseeElPermiso(usuario,Permiso.UsuarioBaja)){
                _repositorio.Eliminar(usuario.Id);
            }
        }catch(PermisosException ex){
            Console.WriteLine($"ERROR EN BAJA DE USUARIO POR {ex}");
        }
    }
}
