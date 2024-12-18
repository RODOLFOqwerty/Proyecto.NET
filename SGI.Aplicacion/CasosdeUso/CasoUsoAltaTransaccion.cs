using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoAltaTransaccion(IRepositorio<Transaccion> _repositorio,IRepositorio<Producto> _repositorioProducto, TransaccionValidacion _validador, IServicioAutorizacion _servicioAutorizacion)
    {

        public void Ejecutar(Transaccion transaccion, Usuario usuario)
        {
           try{
            if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
            
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
            }else{
                throw new PermisosException("No tiene los permisos");
            }      
           }catch(Exception ex){
            Console.WriteLine($"ERROR EN ALTA TRANSACCION POR {ex}");
           }
        }

    }
}
