using datosJson;
using System.Text.Json;
using clasePersonajes;
using clasesConsumoAPI;
using PersonajesRyM;
using TextosConsola;
internal class Program
{
    private static void Main(string[] args)
    {
        int aux = 0, resultado = 0;
        string? opcion;
        List<personaje> listaPjs = FabricaDePersonajes.GenerarPjs();

        do
        {
            if (resultado == 0)
            {
                Console.Clear();
                Textos.Menu();
                opcion = Console.ReadLine();
                int.TryParse(opcion, out aux);
                Console.Clear();
            }else{
                Console.Clear();
                Textos.MenuFinal(resultado);
                opcion = Console.ReadLine();
                int.TryParse(opcion, out aux);
                Console.Clear();
            }

            switch (aux)
            {
                case 1:
                    Textos.MostrarPersonajes(listaPjs);
                    Textos.TeclaPasar();
                    break;
                case 2:
                    if (resultado == 0)
                    {
                        resultado = Juego(ref listaPjs);
                    }else{
                        Textos.MostrarEnemigos(listaPjs);
                        Textos.TeclaPasar();
                    }
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        } while (aux != 3);
    }

//------------------------------------------------------------------------------------------------------------------
    public static int Juego(ref List<personaje> listaPjs)           //Metodo donde se desarrolla el juego
    {
        int resultado = 0, nivel = 1, aux = 0, pj = 0;
        string? opcion;
        Console.Clear();
        Textos.ElegirPj(listaPjs);
        opcion = Console.ReadLine();
        int.TryParse(opcion, out pj);
        Console.Clear();
        do
        {
            if (resultado == 0)         //control de estado de la partida
            {    
                aux = 0;
                aux = BatallaNivel(ref listaPjs, nivel, pj);
                
                if (aux == 0)           //control de paso de nivel
                {
                    Textos.GameOver(listaPjs, pj, nivel);
                    Textos.TeclaPasar();
                    resultado = 2;
                }else{
                    if (nivel != 5)
                    {
                        nivel++;
                        listaPjs[pj].Nivel++;
                        if (listaPjs[pj].Hp + 50 > 100)
                        {
                            listaPjs[pj].Hp = 100;
                        }else{
                            listaPjs[pj].Hp += 50;
                        }
                    }
                    Textos.PasoNivel(listaPjs, pj, nivel);
                    Textos.TeclaPasar();
                }
            }else{
                return resultado;
            }
        } while (nivel < 6);
        resultado = 1;
        return resultado;
    }

//------------------------------------------------------------------------------------------------------------------

    public static int BatallaNivel(ref List<personaje> listaPjs, int Nivel, int Pj)     //Metodo donde se desarrolla cada batalla
    {
        Random rnd = new Random();
        string? opcion;
        int accion = 0, ataque = 0;
        bool defensaFlag;
        personaje Personaje = listaPjs[Pj];
        personaje Enemigo = listaPjs[Nivel+1];
        
        Console.Clear();
        Console.WriteLine($"Batalla Nivel {Nivel}");
        Textos.MostrarPj(listaPjs, Pj);
        Textos.MostrarEnemigo(listaPjs, Nivel);
        Textos.TeclaPasar();
        while (Personaje.Hp > 0 && Enemigo.Hp > 0)
        {
            defensaFlag = false;    //reseteo de defenseFlag
            Console.Clear();
            Console.WriteLine($"Batalla Nivel {Nivel}");
            Console.WriteLine("=======================");
            Console.WriteLine($"{Personaje.Name} --- {Personaje.Hp}");
            Console.WriteLine("\tVs");
            Console.WriteLine($"{Enemigo.Name} --- {Enemigo.Hp}");
            Console.WriteLine("=======================");
            Textos.MenuBatalla();
            opcion = Console.ReadLine();
            int.TryParse(opcion, out accion);
            Console.Clear();

            if (accion == 1)          //ejecucion de accion
            {
                ataque = danio(Personaje, Enemigo);     //calculo de danio
                Console.WriteLine($"Danio provocado al enemigo: {ataque}");
                if (Enemigo.Hp - ataque >= 0)
                {
                    Enemigo.Hp -= ataque;
                }else{
                    Enemigo.Hp = 0;
                }
                Console.WriteLine($"Vida del enemigo: {Enemigo.Hp}");
            }else{
                defensaFlag = defensa(Personaje);       //determina efectividad de defensa
                if (defensaFlag)
                {
                    Console.WriteLine("La defense fue exitosa, ataque enemigo resistido");
                }else{
                    Console.WriteLine("La defense fallo");
                }
            }

            if (defensaFlag == false)
            {
                Console.WriteLine("=======================");
                ataque = danio(Enemigo, Personaje);     //calculo de danio enemigo
                Console.WriteLine($"Danio provocado por el enemigo: {ataque}");
                if (Personaje.Hp - ataque >= 0)
                {
                    Personaje.Hp -= ataque;
                }else{
                    Personaje.Hp = 0;
                }
                Console.WriteLine($"Vida de {Personaje.Name}: {Personaje.Hp}");
                Console.WriteLine("=======================");
            }
            Textos.TeclaPasar();
        }
        listaPjs[Pj] = Personaje;
        listaPjs[Nivel+1] = Enemigo;
        if (Personaje.Hp == 0)
        {
            return 0;
        }else{
            return 1;
        }
    }

//------------------------------------------------------------------------------------------------------------------
    public static int danio(personaje Pj, personaje Enemigo)        //Metodo donde se calcula el danio generado
    {
        Random rnd = new Random();
        int ataque = Pj.Dest * Pj.Fuerza * Pj.Nivel;
        int efectividad = rnd.Next(1, 100);
        int defensa = Enemigo.Arm * Enemigo.Vel;
        const int ajuste = 500;
        int danio = ((ataque * efectividad) - defensa) / ajuste;
        return danio;
    }

//------------------------------------------------------------------------------------------------------------------
    public static bool defensa(personaje Pj)                        //Metodo donde se determina la efectividad de Defensa
    {
        Random rnd = new Random();
        int efectividad = rnd.Next(1, 101);
        if (efectividad >= 75)
        {
            return true;
        }else{
            return false;
        }
    }
}
