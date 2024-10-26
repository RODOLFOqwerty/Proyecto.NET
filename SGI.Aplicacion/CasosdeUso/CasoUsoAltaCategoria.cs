using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaCategoria(IRepositorio<Categoria> _repositorio, IServicioAutorizacion _servicioAutorizacion, IValidacion<Categoria> validador)
    {
        

    public void Ejecutar(Categoria categoria, Usuario usuario)
    {
        _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);

        categoria.id = _repositorio.ObtenerNuevoId();        
        validador.Validar(categoria); // Validar la categoría antes de agregar

        _repositorio.Agregar(categoria); // Agregar la categoría al repositorio
    }


    }
}
