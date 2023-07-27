using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using clasePersonajes;

namespace datosJson
{
//Persistencia de datos - clase para guardar y leer archivos desde un archivo Json
    public class PersonajesJson
    {
        public static bool existeArchivo(string archivo)
        {
            return File.Exists(archivo);
        }
        public static void guardarPersonajes(List<personaje> lista)
        {
            string contenidoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText("personajes.json", contenidoJson);
        }
        public static List<personaje> leerPersonajes(string archivo)
        {
            string contenidoJson = File.ReadAllText(archivo);
            List<personaje>? listapersonajes = JsonSerializer.Deserialize<List<personaje>>(contenidoJson);
            return listapersonajes;
        }
    }
}