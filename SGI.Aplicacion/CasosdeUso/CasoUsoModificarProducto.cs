using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoModificarProducto
    {
        private readonly IRepositorio<Producto> _repositorio;
        private readonly IValidacion<Producto> _validador = new ProductoValidacion();
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();

        public CasoUsoModificarProducto(IRepositorio<Producto> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(Producto producto, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaModificacion);

            _validador.Validar(producto);
            _repositorio.Eliminar(producto.id);
            _repositorio.Agregar(producto);
        }
    }
}
