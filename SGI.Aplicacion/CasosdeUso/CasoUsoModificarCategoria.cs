using System.Collections;
using System.Net.Http.Headers;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso;

public class CasoUsoModificarCategoria
{
        private readonly IRepositorio<Categoria> _repositorio;
        private readonly IValidacion<Categoria> _validador = new CategoriaValidador();
        private readonly IServicioAutorizacion _servicioAutorizacion= new ServicioAutorizacion();

        public CasoUsoModificarCategoria(IRepositorio<Categoria> repositorioc){
            _repositorio = repositorioc;
        }

        public void Ejecutar(Categoria c,Usuario usuario){
            _servicioAutorizacion.PoseeElPermiso(usuario.Id,Permiso.CategoriaModificacion);
            _validador.Validar(c);
            _repositorio.Eliminar(c.id);
            _repositorio.Agregar(c);
        }
}
