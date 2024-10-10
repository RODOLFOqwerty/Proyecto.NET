using SGI.Aplicacion.Interfaces;
using SGI.Aplicacion.Entidades;
using SGI.Aplicacion;

namespace SGI;

public class Repositorio_Categoria : IRepositorio<Categoria>
{
    private readonly string filePath = "categorias.txt";

    public void Agregar(Categoria categoria)
    {
        var linea = $"{categoria.id},{categoria.nombre},{categoria.descripcion},{categoria.fechaC},{categoria.fechaUM}";
        File.AppendAllLines(filePath, new[] { linea });
    }

    public Categoria ObtenerPorId(int id)
    {
        var lineas = File.ReadAllLines(filePath);
        var linea = lineas.FirstOrDefault(l => l.StartsWith(id.ToString()));
        if (linea == null)
        {
            throw new KeyNotFoundException("Categoria no encontrada");
        }
        return ConvertirACategoria(linea);
    }

    public IEnumerable<Categoria> Listar()
    {
        if (!File.Exists(filePath))
            return new List<Categoria>();  

        var lineas = File.ReadAllLines(filePath);
        return lineas.Select(ConvertirACategoria).ToList();  
    }

    public void Eliminar(int id)
    {
        var lineas = File.ReadAllLines(filePath).Where(l => !l.StartsWith(id.ToString())).ToList();
        File.WriteAllLines(filePath, lineas);
    }

    private Categoria ConvertirACategoria(string linea)
    {
        var partes = linea.Split(',');
        return new Categoria
        {
            id = int.Parse(partes[0]),
            nombre = partes[1],
            descripcion = partes[2],
            fechaC = DateTime.Parse(partes[3]),
            fechaUM = DateTime.Parse(partes[4])
        };
    }

    public int ObtenerNuevoId()
    {
        if (!File.Exists(filePath)) return 1;  // Si no existe el archivo, empieza con ID 1.
        var ultimaLinea = File.ReadAllLines(filePath).LastOrDefault();
        return ultimaLinea != null ? int.Parse(ultimaLinea.Split(',')[0]) + 1 : 1;
    }
}