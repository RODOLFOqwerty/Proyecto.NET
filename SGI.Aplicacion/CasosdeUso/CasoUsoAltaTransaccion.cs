using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaTransaccion
    {
        private readonly IRepositorio<Transaccion> _repositorio;
        private readonly TransaccionValidacion _validador;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IRepositorio<Producto> _repositorioProducto;

        public CasoUsoAltaTransaccion(
            IRepositorio<Transaccion> repositorio, 
            TransaccionValidacion validador, 
            IServicioAutorizacion servicioAutorizacion, 
            IRepositorio<Producto> repositorioProducto)
        {
            _repositorio = repositorio;
            _validador = validador; 
            _servicioAutorizacion = servicioAutorizacion;
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(Transaccion transaccion, Usuario usuario)
        {
            if (!usuario.PoseePermiso(Permiso.TransaccionAlta))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de alta transacciones.");
            }

            var producto = _repositorioProducto.ObtenerPorId(transaccion.productoid);
            _validador.Validar(transaccion, producto);
            _repositorio.Agregar(transaccion);
        }

    }
}
