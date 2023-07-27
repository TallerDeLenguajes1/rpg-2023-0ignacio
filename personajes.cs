using System.Text.Json;
namespace clasePersonajes
{
    //Estructura del personaje
    public class personaje
    {
        private string? especie;
        private string? name;
        private string? origen;
        private int vel;
        private int dest;
        private int fuerza;
        private int nivel;
        private int arm;
        private int hp;

        public string? Especie { get => especie; set => especie = value; }
        public string? Name { get => name; set => name = value; }
        public string? Origen { get => origen; set => origen = value; }
        public int Vel { get => vel; set => vel = value; }
        public int Dest { get => dest; set => dest = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Arm { get => arm; set => arm = value; }
        public int Hp { get => hp; set => hp = value; }
    }
    //Clase para la creacion aleatoria de personajes
    public class FabricaDePersonajes
    {
        string[] clases = { "Tanque", "Arquero", "Mago", "Apoyo", "Barbaro" };
        //Metodo para cargar caracteristicas del personaje
        public personaje crearPersonaje(string? nameX, string? speciesX, string? originX)
        {
            personaje nuevo = new personaje();
            Random rnd = new Random();
            int auxTipo = rnd.Next(0, 5);
            nuevo.Especie = speciesX;
            int auxName = rnd.Next(0, 5);
            nuevo.Name = nameX;
            nuevo.Origen = originX;
            nuevo.Hp = 100;
            nuevo.Nivel = rnd.Next(1, 11);
            nuevo.Arm = rnd.Next(1, 11);
            nuevo.Dest = rnd.Next(1, 6);
            nuevo.Vel = rnd.Next(1, 11);
            nuevo.Fuerza = rnd.Next(1, 11);

            return nuevo;
        }
    }
}