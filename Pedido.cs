
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
    private Cadete cadeteAsignado;
    public int Numero { get => numero; }
    public string Observacion { get => observacion; }
    public Estados Estado { get => estado; set => estado = value; }
    public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }
    public Pedido(int nro, string obs, string nombre, string direcc, string telefono, string referencias)
    {
        numero = nro;
        observacion = obs;
        Estado = Estados.Preparación;
        cliente = new Cliente(nombre, direcc, telefono, referencias);
        cadeteAsignado = new Cadete(1, nombre,"sadas",telefono);
    }
}