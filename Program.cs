using clasePersonajes;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information

personaje nuevo;
List<personaje> listaPjs = new List<personaje>();
List<personaje> listaNueva = new List<personaje>();
FabricaDePersonajes fp = new FabricaDePersonajes();
for (int i = 0; i < 5; i++)
{
    nuevo = fp.crearPersonaje();
    listaPjs.Add(nuevo);
}

personajesJson pjson = new personajesJson();

if (pjson.existeArchivo("personajes.json"))
{
    Console.WriteLine("Existe");
}else{
    Console.WriteLine("No Existe");
}

pjson.guardarPjs(listaPjs);

listaNueva = pjson.leerPersonajes("personajes.json");