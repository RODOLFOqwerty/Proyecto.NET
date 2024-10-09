using SGI.Aplicacion.Entidades; 
using SGI.Aplicacion.Interfaces;

namespace SGI.Aplicacion.CasosdeUso
{
    public class CasoUsoBajaCategoria
    {
        private readonly IRepositorio<Categoria> _repositorio;
        private readonly IRepositorio<Producto> _repositorioProducto;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoUsoBajaCategoria(IRepositorio<Categoria> repositorio, IServicioAutorizacion servicioAutorizacion, IRepositorio<Producto> repositorioP)
        {
            _repositorio = repositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _repositorioProducto = repositorioP;
        }

        public void Ejecutar(int id, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, SGI.Aplicacion.Entidades.Permiso.CategoriaBaja))
            {
                throw new PermisosException("El usuario no tiene permisos para dar de baja categorías.");
            }

            
            // Lógica para verificar si la categoría tiene productos asignados
            IEnumerable<Producto> lista = _repositorioProducto.Listar();
            if(!lista.Any(p => p.categoriaId == id)){
                _repositorio.Eliminar(id);
            }else{
                throw new ValidacionException("HAY PRODUCTOS ASIGNADOS A ESA CATEGORIA");
            }
        }
    }
}
