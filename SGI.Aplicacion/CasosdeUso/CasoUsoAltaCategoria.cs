using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaCategoria
    {
        private readonly IRepositorio<Categoria> _repositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();
        public CasoUsoAltaCategoria(IRepositorio<Categoria> repositorio)
        {
            _repositorio = repositorio;
        }

    public void Ejecutar(Categoria categoria, Usuario usuario)
    {
        _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);

        var validador = new CategoriaValidador();

        categoria.id = _repositorio.ObtenerNuevoId();        
        validador.Validar(categoria); // Validar la categoría antes de agregar

        _repositorio.Agregar(categoria); // Agregar la categoría al repositorio
    }


    }
}
