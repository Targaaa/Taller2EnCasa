using System.Text.Json.Serialization;
public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    public int Id { get => id; }
    public string Nombre { get => nombre; }         //metodos para obtener los valores privados
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }

    public Cadete()
    {
    }
    [JsonConstructor]
    public Cadete(int id, string nombre, string direccion, string telefono) //constructor
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}
