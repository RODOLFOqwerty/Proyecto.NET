using System.Collections;
using System.Net.Http.Headers;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Validaciones;

namespace SGI.Aplicacion.CasosdeUso;

public class CasoUsoModificarCategoria(IRepositorio<Categoria> _repositorio, IValidacion<Categoria> _validador, IServicioAutorizacion _servicioAutorizacion)
{
        public void Ejecutar(Categoria c,Usuario usuario){
            
            try{
                if(_servicioAutorizacion.PoseeElPermiso(usuario,Permiso.CategoriaModificacion)){
                    _validador.Validar(c);
                    _repositorio.Modificar(c);
                }
            }catch(RepositoriosException ex){
                Console.WriteLine($"Error en la modificacion por {ex}");
            }catch(PermisosException pex){
                Console.WriteLine($"Error en la modificacion por {pex}");
            }
        }
}
