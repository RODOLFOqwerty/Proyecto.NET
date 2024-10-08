using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaTransaccion
    {
        private readonly IRepositorio<Transaccion> _repositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoBajaTransaccion(IRepositorio<Transaccion> repositorio, IServicioAutorizacion servicioAutorizacion)
        {
            _repositorio = repositorio;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(int id, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TransaccionBaja))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de baja transacciones.");
            }

            _repositorio.Eliminar(id);
        }
    }
}
