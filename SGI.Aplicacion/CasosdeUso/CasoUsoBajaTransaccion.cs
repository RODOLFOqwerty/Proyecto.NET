using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaTransaccion
    {
        private readonly IRepositorio<Transaccion> _repositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();
        private readonly IRepositorio<Producto> _repositorioproducto;
        private readonly IValidacion<Transaccion> _validador = new TransaccionValidacion();

        public CasoUsoBajaTransaccion(IRepositorio<Transaccion> repositorio, IRepositorio<Producto> repositoriop)
        {
            _repositorio = repositorio;
            _repositorioproducto = repositoriop;
        }

        public void Ejecutar(int id, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
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
