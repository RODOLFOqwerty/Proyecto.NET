using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoModificarProducto
    {
        private readonly IRepositorio<Producto> _repositorio;
        private readonly IValidacion<Producto> _validador;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoModificarProducto(IRepositorio<Producto> repositorio, IValidacion<Producto> validador, IServicioAutorizacion servicioAutorizacion)
        {
            _repositorio = repositorio;
            _validador = validador;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(Producto producto, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ProductoModificacion))
            {
                throw new PermisosException("El usuario no tiene permisos para modificar productos.");
            }

            _validador.Validar(producto);
            _repositorio.Eliminar(producto.id);
            _repositorio.Agregar(producto);
        }
    }
}
