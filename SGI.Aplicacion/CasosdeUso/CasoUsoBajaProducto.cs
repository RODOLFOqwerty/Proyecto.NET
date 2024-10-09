using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaProducto
    {
        private readonly IRepositorio<Producto> _repositorio;

        private readonly IRepositorio<Transaccion> _repositorioTransaccion;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoBajaProducto(IRepositorio<Producto> repositorio, IServicioAutorizacion servicioAutorizacion, IRepositorio<Transaccion> repositorioT)
        {
            _repositorio = repositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _repositorioTransaccion =repositorioT;
        }

        public void Ejecutar(int id,int idproducto, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ProductoBaja))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de baja productos.");
            }
            _repositorioTransaccion.Eliminar(idproducto);
            _repositorio.Eliminar(id);
            
        }
    }
}
