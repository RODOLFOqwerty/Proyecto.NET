using SGI.Aplicacion.Entidades;
namespace SGI.Aplicacion.Interfaces;

 public interface IServicioAutorizacion
 {
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);
 }
