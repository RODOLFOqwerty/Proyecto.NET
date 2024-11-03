using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
namespace SGI.Aplicacion;

public class ServicioAutorizacion:IServicioAutorizacion
{
    public bool PoseeElPermiso(Usuario usuario,Permiso permiso){
        return usuario?.Permisos?.Any(p => p == permiso) ?? false;
    }
}
