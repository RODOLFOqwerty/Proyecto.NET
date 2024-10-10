using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using System.Collections;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaProducto
    {
        private readonly IRepositorio<Producto> _repositorio;

        private readonly IRepositorio<Transaccion> _repositorioTransaccion;
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();

        public CasoUsoBajaProducto(IRepositorio<Producto> repositorio, IRepositorio<Transaccion> repositorioT)
        {
            _repositorio = repositorio;
            _repositorioTransaccion =repositorioT;
        }

        public void Ejecutar(int id, Usuario usuario)
        {
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaBaja);
            
            foreach(Transaccion t in _repositorioTransaccion.Listar()){
                if(t.productoid==id){
                    _repositorioTransaccion.Eliminar(t.id);
                }
            }

            
            _repositorio.Eliminar(id);
            
        }
    }
}
