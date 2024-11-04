using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;

namespace SGI.Aplicacion.CasosdeUso;

public class CasoUsoUsuarioAlta(IRepositorio<Usuario> _repositorio, IServicioAutorizacion _servicioAutorizacion, IValidacion<Usuario> _validador)
{
    public void Ejecutar(Usuario actusuario, Usuario otrousuario){
        _servicioAutorizacion.PoseeElPermiso(actusuario,Permiso.UsuarioAlta);
        try{
            _validador.Validar(otrousuario);
            otrousuario.Contraseña = SistemaHashing.getHash(otrousuario.Contraseña ?? "000");
            _repositorio.Agregar(otrousuario);
        }catch(RepositoriosException rex){
            Console.WriteLine($"ERROR EN ALTA USUARIO POR {rex}");
        }catch(ValidacionException vex){
            Console.WriteLine($"ERROR EN ALTA USUARIO POR {vex}");
        }
    }
}
