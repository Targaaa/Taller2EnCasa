public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos; //lista llamada pedidos de tipo Pedido
    public int Id { get => id; }
    public string Nombre { get => nombre; }         //metodos para obtener los valores privados
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; } //al igual que estado el valor va cambiando

    public Cadete(int id, string nombre, string direccion, string telefono) //constructor
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        pedidos = new List<Pedido>(); // a diferencia de en cadeteria this.cadetes = cadetes aqui se genera la lista vacia y no se le pasa ningun valor al constructor
    }
    public int JornalACobrar()
    {
        return 500 * CantidadPedidosCompletados(); //sera un metodo que me devuelva, ya lo haré
    }
    public int CantidadPedidosCompletados()
    {
        return pedidos.Count(p => p.Estado == Estados.Entregado);  //cuenta la cantidad de estados ya entregados con Count de Linq
    }

}
