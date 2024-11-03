using SGI.Aplicacion;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class UsuarioValidacion : IValidacion<Usuario>
{
    public bool Validar(Usuario usuario){
        try{
            if(string.IsNullOrWhiteSpace(usuario.Nombre)){
                throw new ValidacionException("En el nombre no pueden haber espacios en blanco");
            }
            if(string.IsNullOrWhiteSpace(usuario.Apellido)){

            }
            if(string.IsNullOrWhiteSpace(usuario.Email)){

            }
            if(string.IsNullOrWhiteSpace(usuario.Contraseña)){

            }
            return true;
        }catch(ValidacionException ex){
            Console.WriteLine($"Error en la validación del usuario: {ex.Message}");
            return false;
        }
    }
}
