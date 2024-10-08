using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
namespace SGI.Aplicacion;

public class ServicioAutorizacion:IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario,Permiso permiso){
        if(IdUsuario == 1){
            return true;
        }else{
            return false;
        }
    }
}
