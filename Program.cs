using datosJson;
using System.Text.Json;
using clasePersonajes;
using clasesConsumoAPI;
using PersonajesRyM;
internal class Program
{
    private static void Main(string[] args)
    {
        List<personaje> listaPjs = GenerarPjs();
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
            PersonajesJson.guardarPersonajes(ListaPjs);
        }
        return ListaPjs;
    }
}
