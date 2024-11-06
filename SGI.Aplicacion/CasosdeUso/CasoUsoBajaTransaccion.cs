using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaTransaccion(IRepositorio<Transaccion> _repositorio, IRepositorio<Producto> _repositorioproducto, IServicioAutorizacion _servicioAutorizacion, IValidacion<Transaccion> _validador)
    {

        public void Ejecutar(int id, Usuario usuario)
        {
            
            if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                Transaccion t = _repositorio.ObtenerPorId(id);
                if(t!=null){
                    Producto p = _repositorioproducto.ObtenerPorId(t.productoid);
                    _validador.Validar(t);
                    if(p!=null){
                        if(t.tipotransaccion == TipoTransaccion.Entrada){
                            p.stock -= t.cantidad;
                            _repositorioproducto.Modificar(p);
                        }else if(t.tipotransaccion == TipoTransaccion.Salida){
                            p.stock += t.cantidad;
                            _repositorioproducto.Modificar(p);
                        }
                    }
                    _repositorio.Eliminar(id);
                }
            }         
            
        }
    }
}
