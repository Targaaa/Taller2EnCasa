public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; }
    public List<Cadete> Cadetes { get => cadetes; }
    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = cadetes;
    }


}