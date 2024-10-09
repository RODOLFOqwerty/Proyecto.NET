using System.ComponentModel;
namespace SGI.Aplicacion.Entidades;

public class Transaccion {
    public int id { get; set; } 
    public int productoid { get; set; }
    public int cantidad { get; set; }
    public TipoTransaccion tipotransaccion { get; set; } 
    public DateTime fechatransaccion { get; set; }
   
    
    public Transaccion(int productoid,int cantidad, TipoTransaccion tipotransaccion){
        this.productoid = productoid;
        this.cantidad = cantidad;
        this.tipotransaccion = tipotransaccion;
    }

    public Transaccion(){}

}

public enum TipoTransaccion
{
    Entrada, 
    Salida   
}