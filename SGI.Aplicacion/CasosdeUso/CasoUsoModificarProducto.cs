using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoModificarProducto(IRepositorio<Producto> _repositorio, IValidacion<Producto> _validador, IServicioAutorizacion _servicioAutorizacion)
    {
        public void Ejecutar(Producto producto, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaModificacion);

            _validador.Validar(producto);
            _repositorio.Eliminar(producto.id);
            _repositorio.Agregar(producto);
        }
    }
}
