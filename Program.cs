using datosJson;
using System.Text.Json;
using clasePersonajes;
using clasesConsumoAPI;
using PersonajesRyM;
// See https://aka.ms/new-console-template for more information

personaje nuevo;
List<personaje> listaPjs = new List<personaje>();
List<personaje> listaNueva = new List<personaje>();
FabricaDePersonajes fp = new FabricaDePersonajes();

if (PersonajesJson.existeArchivo("personajes.json"))
{
    Console.WriteLine("La lista de personajes existe.");
    Console.WriteLine("Personajes cargados.");
    listaNueva = PersonajesJson.leerPersonajes("personajes.json");
}else{
    Console.WriteLine("La lista de personajes no existe, se creara una lista aleatoria.");
    for (int i = 0; i < 10; i++)
    {
        nuevo = fp.crearPersonaje();
        listaPjs.Add(nuevo);
    }
    PersonajesJson.guardarPersonajes(listaPjs);
}

List<PersonajeRyM> ListaPjs = ConsumirAPI.GetApi();