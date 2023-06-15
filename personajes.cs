namespace personajes;

public class personaje{
    private string? tipo;
    private string? name;
    private DateTime fecNac;
    private int edad;
    private int vel;
    private int dest;
    private int fuerza;
    private int nivel;
    private int arm;
    private int hp;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Name { get => name; set => name = value; }
    public DateTime FecNac { get => fecNac; set => fecNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Vel { get => vel; set => vel = value; }
    public int Dest { get => dest; set => dest = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Arm { get => arm; set => arm = value; }
    public int Hp { get => hp; set => hp = value; }
    
}