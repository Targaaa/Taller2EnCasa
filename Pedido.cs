
public enum Estados
{
    Preparación,
    EnCamino,
    Entregado
};

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private Estados estado;

    public int Numero { get => numero; }
    public string Observacion { get => observacion; }
    public Estados Estado { get => estado; set => estado = value; }

    public Pedido(int nro, string obs, string nombre, string direcc, string telefono, string referencias)
    {
        numero = nro;
        observacion = obs;
        Estado = Estados.Preparación;
        cliente = new Cliente(nombre, direcc, telefono, referencias);
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Direccion: {cliente.Direccion}");
        if (cliente.DatosReferenciasDireccion != null)
        {
            Console.WriteLine($"Referencias del domicilio: {cliente.DatosReferenciasDireccion}");
        }
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Direccion: {cliente.Direccion}");
        Console.WriteLine($"Telefono: {cliente.Telefono}");
    }
    public static Pedido DarDeAltaPedido(int nroPedido)
    {
        string observacion;
        string nombreCliente;
        string direccionCliente;
        string telefonoCliente;
        string refCliente;
        do
        {
            Console.WriteLine("Ingrese el pedido:");
            observacion = Console.ReadLine();
            Console.WriteLine("Ingrese el cliente");
            nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección");
            direccionCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del cliente");
            telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese una referencia de la dirección: ");
            refCliente = Console.ReadLine();
        } while (string.IsNullOrEmpty(observacion) || string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(direccionCliente) || string.IsNullOrEmpty(telefonoCliente));
        Pedido pedido1 = new Pedido(nroPedido, observacion, nombreCliente, direccionCliente, telefonoCliente, refCliente);
        return pedido1;
    }

    public static void MostrarPedido(Pedido pedido)
    {
        if (pedido != null)
            {  
                Console.WriteLine($"Pedido N°: {pedido.Numero}");
                Console.WriteLine($"Observaciones: {pedido.Observacion}");
                Console.WriteLine($"Estado: {pedido.Estado}");
                pedido.VerDatosCliente();
            }else
            {
                Console.WriteLine("No existe ese pedido");
            }
    }
}