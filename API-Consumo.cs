using System.Net;
using System.Text.Json;
using ApiRickAndMorty;
using PersonajesRyM;
namespace clasesConsumoAPI
{
    public class ConsumirAPI
    {
        public static List<PersonajeRyM> GetApi()
        {
            var url = $"https://rickandmortyapi.com/api/episode/29";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try{
                using(WebResponse response = request.GetResponse())
                {
                    using(Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            PersonajeRyM nuevo;
                            int aux = 0;
                            List<PersonajeRyM> listaPjs = new List<PersonajeRyM>();
                            string responseBody = objReader.ReadToEnd();
                            ApiRyM? contenidoApi = JsonSerializer.Deserialize<ApiRyM>(responseBody);
                            while(listaPjs.Count < 2)
                            {
                                nuevo = GetPersonajeRyM(contenidoApi.Characters[aux]);
                                if (nuevo.Species == "Human")
                                {
                                    listaPjs.Add(nuevo);
                                }
                                aux++;
                            }
                            while(listaPjs.Count < 7)
                            {
                                nuevo = GetPersonajeRyM(contenidoApi.Characters[aux]);
                                if (nuevo.Species == "Alien")
                                {
                                    listaPjs.Add(nuevo);
                                }
                                aux++;
                            }
                            return listaPjs;
                        }
                    }
                }
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return null;
            }
        }

        public static PersonajeRyM GetPersonajeRyM(string? urlPj)
        {
            var url = urlPj;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try{
                using(WebResponse response = request.GetResponse())
                {
                    using(Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            PersonajeRyM? datosPersonaje = JsonSerializer.Deserialize<PersonajeRyM>(responseBody);
                            return datosPersonaje;
                        }
                    }
                }
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return null;
            }
        }
    }
}