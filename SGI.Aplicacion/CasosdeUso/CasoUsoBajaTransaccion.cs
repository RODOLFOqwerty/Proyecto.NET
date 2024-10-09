using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaTransaccion
    {
        private readonly IRepositorio<Transaccion> _repositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IRepositorio<Producto> _repositorioproducto;

        public CasoUsoBajaTransaccion(IRepositorio<Transaccion> repositorio, IServicioAutorizacion servicioAutorizacion, IRepositorio<Producto> repositoriop)
        {
            _repositorio = repositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _repositorioproducto = repositoriop;
        }

        public void Ejecutar(int id, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TransaccionBaja))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de baja transacciones.");
            }
            Transaccion t = _repositorio.ObtenerPorId(id);
            if(t!=null){
                Producto p = _repositorioproducto.ObtenerPorId(t.productoid);
                if(p!=null){
                    _repositorioproducto.Eliminar(p.id);
                    if(t.tipotransaccion == TipoTransaccion.Entrada){
                        p.stock -= t.cantidad;
                        p.fechaUM = DateTime.Now;
                        _repositorioproducto.Agregar(p);
                    }else if(t.tipotransaccion == TipoTransaccion.Salida){
                        p.stock += t.cantidad;
                        p.fechaUM = DateTime.Now;
                        _repositorioproducto.Agregar(p);
                    }
                }
                _repositorio.Eliminar(id);
            }

            
            
        }
    }
}
