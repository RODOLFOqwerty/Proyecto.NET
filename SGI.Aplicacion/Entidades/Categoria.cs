
namespace SGI.Aplicacion.Entidades;

public class Categoria
{    
    public int id { get; set; }
    public string nombre { get; set; } = "";
    public string descripcion { get; set;} = "";
    public DateTime fechaC {get;set;}
    public DateTime fechaUM {get;set;}

    public Categoria(string nombre, string descripcion){
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.fechaC = DateTime.Today;
        this.fechaUM = DateTime.Today;
    }
    public Categoria(){}
}
