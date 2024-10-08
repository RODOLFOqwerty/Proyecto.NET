namespace SGI.Aplicacion.Entidades;

public class Producto
{
    public int id {get;set;}
    public string nombre {get;set;} ="";
    public string descripcion {get;set;} ="";
    public float precioUnitario {get;set;}
    public int stock {get;set;}
    public DateTime fechaC {get;set;}
    public DateTime fechaUM {get;set;}
    public int categoriaId { get; set; }

    public Producto(string Nombre, string Descripcion, float PrecioUnitario, int Stock) {
        this.nombre = Nombre;
        this.descripcion = Descripcion;
        this.precioUnitario = PrecioUnitario;
        this.stock = Stock;
        this.fechaC = DateTime.Today;
        this.fechaUM = DateTime.Today;
    }




    public Producto(){}

   



    public void IncrementarStock() {
        stock++;
    }

    public void DecrementarStock() {
        if (stock > 0) {
            stock--;
        }
    }



}
