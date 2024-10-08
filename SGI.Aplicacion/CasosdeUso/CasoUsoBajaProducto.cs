using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaProducto
    {
        private readonly IRepositorio<Producto> _repositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoBajaProducto(IRepositorio<Producto> repositorio, IServicioAutorizacion servicioAutorizacion)
        {
            _repositorio = repositorio;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(int id, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ProductoBaja))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de baja productos.");
            }

            _repositorio.Eliminar(id);
        }
    }
}
