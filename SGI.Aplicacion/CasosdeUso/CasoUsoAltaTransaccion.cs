using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaTransaccion
    {
        private readonly IRepositorio<Transaccion> _repositorio;
        private readonly TransaccionValidacion _validador = new TransaccionValidacion();
        private readonly IServicioAutorizacion _servicioAutorizacion = new ServicioAutorizacion();
        private readonly IRepositorio<Producto> _repositorioProducto;

        public CasoUsoAltaTransaccion(IRepositorio<Transaccion> repositorio,IRepositorio<Producto> repositorioProducto)
        {
            _repositorio = repositorio;
            _repositorioProducto = repositorioProducto;
        }

        public void Ejecutar(Transaccion transaccion, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
            transaccion.id=_repositorio.ObtenerNuevoId();
            Producto p = _repositorioProducto.ObtenerPorId(transaccion.productoid);
            if(p!=null){
                if(transaccion.tipotransaccion==TipoTransaccion.Entrada){
                    _repositorioProducto.Eliminar(transaccion.productoid);
                    p.fechaUM = DateTime.Now;
                    p.stock += transaccion.cantidad;
                    _repositorioProducto.Agregar(p);                   
                }else{
                    _validador.Validar(transaccion,p);
                    p.fechaUM = DateTime.Now;
                    p.stock -= transaccion.cantidad;
                    _repositorioProducto.Eliminar(transaccion.productoid);
                    _repositorioProducto.Agregar(p);
                }
                _validador.Validar(transaccion);
                _repositorio.Agregar(transaccion);
            }else{
                throw new Exception("El producto no existe");
            }
            
        }

    }
}
