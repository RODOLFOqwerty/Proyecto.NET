using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class CasoUsoBajaUsuario(IRepositorio<Usuario> _repositorio, IServicioAutorizacion _servicioautorizacion)
{
    public void Ejecutar(Usuario usuario, Permiso permiso){
        _servicioautorizacion.PoseeElPermiso(usuario,permiso);
    }
}
