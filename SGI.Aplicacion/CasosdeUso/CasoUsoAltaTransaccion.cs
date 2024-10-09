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
            if(transaccion.tipotransaccion == TipoTransaccion.Entrada){
                Producto p = _repositorioProducto.ObtenerPorId(transaccion.productoid);
                if(p!=null){
                    _repositorioProducto.Eliminar(transaccion.productoid);
                    p.fechaUM = DateTime.Now;
                    p.stock += transaccion.cantidad;
                    _repositorioProducto.Agregar(p);
                    _repositorio.Agregar(transaccion);
                }else{
                    throw new ValidacionException($"El producto con id {transaccion.productoid} no fue encontrado");
                }
            }else if(transaccion.tipotransaccion == TipoTransaccion.Salida){
                Producto p = _repositorioProducto.ObtenerPorId(transaccion.productoid);
                if(p!=null){
                    _repositorioProducto.Eliminar(transaccion.productoid);
                    p.fechaUM = DateTime.Now;
                    p.stock -= transaccion.cantidad;
                    _repositorioProducto.Agregar(p);
                    _repositorio.Agregar(transaccion);
                }else{
                    throw new ValidacionException($"El producto con id {transaccion.productoid} no fue encontrado");
                }
            }
            
        }

    }
}
