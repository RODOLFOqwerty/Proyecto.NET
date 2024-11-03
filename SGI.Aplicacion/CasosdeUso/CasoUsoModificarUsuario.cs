using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class CasoUsoModificarUsuario(IRepositorio<Usuario> _repositorio, IServicioAutorizacion _servicioautorizacion)
{
    public void Ejecutar(Usuario usuario, Usuario usuariomodificar){
        _servicioautorizacion.PoseeElPermiso(usuario,Permiso.UsuarioModificacion);
    }
}
