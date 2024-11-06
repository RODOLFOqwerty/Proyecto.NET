using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using System.Collections;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaProducto(IRepositorio<Producto> _repositorio, IRepositorio<Transaccion> _repositorioTransaccion, IServicioAutorizacion _servicioAutorizacion)
    {
       
        public void Ejecutar(int id, Usuario usuario)
        {
            
            if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaBaja)){
                foreach(Transaccion t in _repositorioTransaccion.Listar()){
                    if(t.productoid==id){
                        _repositorioTransaccion.Eliminar(t.id);
                    }
                }
                 _repositorio.Eliminar(id);
            }else{
                throw new PermisosException("El usuario no cuenta con los permisos");
            }
            
            
            
            
        }
    }
}
