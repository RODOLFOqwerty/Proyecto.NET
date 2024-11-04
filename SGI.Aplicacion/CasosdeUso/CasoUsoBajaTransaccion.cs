using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaTransaccion(IRepositorio<Transaccion> _repositorio, IRepositorio<Producto> _repositorioproducto, IServicioAutorizacion _servicioAutorizacion, IValidacion<Transaccion> _validador)
    {

        public void Ejecutar(int id, Usuario usuario)
        {
            try{
                if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
            Transaccion t = _repositorio.ObtenerPorId(id);
            if(t!=null){
                Producto p = _repositorioproducto.ObtenerPorId(t.productoid);
                _validador.Validar(t);
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
            }catch(Exception ex){
                Console.WriteLine($"ERROR EN BAJA DE TRASNSACCION POR {ex}");
            }

            
            
        }
    }
}
