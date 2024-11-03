using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso;

public class CasoUsoUsuarioAlta(IRepositorio<Usuario> _repositorio, IServicioAutorizacion _servicioAutorizacion, IValidacion<Categoria> validador)
{
    public void Ejecutar(Usuario actusuario, Usuario otrousuario, Permiso permiso){
        _servicioAutorizacion.PoseeElPermiso(actusuario,permiso);
    }
}
