using System.Text.Json;
using datosJson;
using clasesConsumoAPI;
using PersonajesRyM;
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
        //Metodo para cargar caracteristicas del personaje
        public personaje crearPersonaje(string? nameX, string? speciesX, string? originX)
        {
            personaje nuevo = new personaje();
            Random rnd = new Random();
            nuevo.Especie = speciesX;
            nuevo.Name = nameX;
            nuevo.Origen = originX;
            nuevo.Hp = 100;
            if (nuevo.Especie == "Human")
            {
                nuevo.Nivel = 5;
            }else{
                switch (nuevo.Name)
                {
                    case "Beebo":
                        nuevo.Nivel = 1;
                        break;
                    case "Collector":
                        nuevo.Nivel = 3;
                        break;
                    case "Gobo":
                        nuevo.Nivel = 5;
                        break;
                    case "Voltematron":
                        nuevo.Nivel = 7;
                        break;
                    case "Zick Zack":
                        nuevo.Nivel = 9;
                        break;
                    default:
                        break;
                }
            }
            nuevo.Arm = rnd.Next(1, 11);
            nuevo.Dest = rnd.Next(1, 6);
            nuevo.Vel = rnd.Next(1, 11);
            nuevo.Fuerza = rnd.Next(1, 11);
            return nuevo;
        }

        public static List<personaje> GenerarPjs()
        {
            List<personaje> ListaPjs = new List<personaje>();

            if (PersonajesJson.existeArchivo("personajes.json"))
            {
                Console.WriteLine("La lista de personajes existe.");
                Console.WriteLine("Personajes cargados.");
                ListaPjs = PersonajesJson.leerPersonajes("personajes.json");
            }
            else
            {
                FabricaDePersonajes fp = new FabricaDePersonajes();
                personaje nuevo;
                Console.WriteLine("La lista de personajes no existe, se creara una lista aleatoria.");
                List<PersonajeRyM> ListaAux = ConsumirAPI.GetApi();
                for (int i = 0; i < 7; i++)
                {
                    nuevo = fp.crearPersonaje(ListaAux[i].Name, ListaAux[i].Species, ListaAux[i].Origin.Name);
                    ListaPjs.Add(nuevo);
                }
                PersonajesJson.guardarPersonajes(ListaPjs, "personajes.json");
            }
            return ListaPjs;
        }
    }
}