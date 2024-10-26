using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;
namespace SGI.Aplicacion.CasosdeUso

{
    public class CasoUsoAltaProducto(IRepositorio<Producto> _repositorio, IValidacion<Producto> _validador, IServicioAutorizacion _servicioAutorizacion)
    {
        public void Ejecutar(Producto producto, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
            producto.id = _repositorio.ObtenerNuevoId();
            _validador.Validar(producto);
            _repositorio.Agregar(producto);
        }

    }
}
