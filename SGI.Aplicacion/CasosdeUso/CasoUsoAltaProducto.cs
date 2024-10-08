using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
namespace SGI.Aplicacion.CasosdeUso

{
    public class CasoUsoAltaProducto
    {
        private readonly IRepositorio<Producto> _repositorio;
        private readonly IValidacion<Producto> _validador;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoAltaProducto(IRepositorio<Producto> repositorio, IValidacion<Producto> validador, IServicioAutorizacion servicioAutorizacion)
        {
            _repositorio = repositorio;
            _validador = validador;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(Producto producto, Usuario usuario)
        {
            if (!usuario.PoseePermiso(Permiso.ProductoAlta))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de alta productos.");
            }

            _validador.Validar(producto);
            _repositorio.Agregar(producto);
        }

    }
}
