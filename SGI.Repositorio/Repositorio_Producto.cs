using SGI.Aplicacion.Entidades;
using SGI.Aplicacion.Interfaces;

namespace SGI;

public class Repositorio_Producto : IRepositorio<Producto>
{
    //private readonly string _filePath = "Producto.txt";
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(),"Productos.txt");
    public void Agregar(Producto producto){
        var linea = $"{producto.id},{producto.nombre},{producto.descripcion},{producto.precioUnitario},{producto.stock},{producto.fechaC},{producto.fechaUM},{producto.categoriaId}";
        File.AppendAllLines(_filePath, new[] { linea });
    }


    public IEnumerable<Producto> Listar()  
    {
        if (!File.Exists(_filePath))
            return new List<Producto>();  
        var lineas = File.ReadAllLines(_filePath);
        return lineas.Select(ConvertirAProducto).ToList();  
    }



    public void Eliminar(int id){
        if (!File.Exists(_filePath)) return;
        var lineas = File.ReadAllLines(_filePath).Where(l => !l.StartsWith(id.ToString())).ToList();
        File.WriteAllLines(_filePath, lineas);
    }

    public Producto ObtenerPorId(int id)
    {
        var lineas = File.ReadAllLines(_filePath);
        var linea = lineas.FirstOrDefault(l => l.StartsWith(id.ToString()));
        if (linea == null)
        {
            throw new KeyNotFoundException($"Producto con ID {id} no encontrado."); 
        }
        return ConvertirAProducto(linea);
    }


    private Producto ConvertirAProducto(string linea)
    {
        var partes = linea.Split(',');
        return new Producto
        {
            id = int.Parse(partes[0]),
            nombre = partes[1],
            descripcion = partes[2],
            precioUnitario = float.Parse(partes[3]),
            stock = int.Parse(partes[4]),
            fechaC = DateTime.Parse(partes[5]),
            fechaUM = DateTime.Parse(partes[6]),
            categoriaId = int.Parse(partes[7])
        };
    }
        public int ObtenerNuevoId()
    {
        if (!File.Exists(_filePath)) return 1;  // Si no existe el archivo, empieza con ID 1.
        String[] lineas = File.ReadAllLines(_filePath);
        if (lineas.Length==0) return 1;
        
        var ids = lineas.Select(lineas => int.Parse(lineas.Split(',')[0])).ToList();
        return ids.Max()+1;
    }
}
