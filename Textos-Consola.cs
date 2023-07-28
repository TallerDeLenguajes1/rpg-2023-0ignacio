using clasePersonajes;
namespace TextosConsola
{
    public class Textos
    {
        public static void TeclaPasar()
        {
            Console.WriteLine("Precione una tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Menu()
        {
            Console.WriteLine("RICK & MORTY");
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Personajes");
            Console.WriteLine("2 - Iniciar partida");
            Console.WriteLine("3 - Salir");
            Console.WriteLine("=======================");
            Console.WriteLine("Ingresar opcion: ");
        }
        public static void MenuBatalla()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Defender (25%)");
            Console.WriteLine("=======================");
            Console.WriteLine("Ingresar opcion: ");
        }
        public static void MenuFinal(int resultado)
        {
            Console.WriteLine("RICK & MORTY");
            Console.WriteLine("=======================");
            if (resultado == 1)
            {
                Console.WriteLine("WINNER");
            }else{
                Console.WriteLine("GAME OVER");
            }
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Personajes");
            Console.WriteLine("2 - Enemigos");
            Console.WriteLine("3 - Salir");
            Console.WriteLine("=======================");
            Console.WriteLine("Ingresar opcion: ");
        }
        public static void ElegirPj(List<personaje> listaPj)
        {
            Console.WriteLine("Elige un personaje");
            Console.WriteLine("=======================");
            MostrarPersonajes(listaPj);
            Console.WriteLine("0 - Rick");
            Console.WriteLine("1 - Morty");
            Console.WriteLine("=======================");
            Console.WriteLine("Ingresar opcion: ");
        }
        public static void MostrarPersonajes(List<personaje> lista)
        {
            Console.WriteLine("Personajes");
            Console.WriteLine("=======================");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{lista[i].Name}:");
                Console.WriteLine($"Especie: {lista[i].Especie}");
                Console.WriteLine($"Origen: {lista[i].Origen}");
                Console.WriteLine("Caracteristicas:");
                Console.WriteLine($"Velocidad: {lista[i].Vel}");
                Console.WriteLine($"Destreza: {lista[i].Dest}");
                Console.WriteLine($"Fuerza: {lista[i].Fuerza}");
                Console.WriteLine($"Nivel: {lista[i].Nivel}");
                Console.WriteLine($"Armadura: {lista[i].Arm}");
                Console.WriteLine($"Vida: {lista[i].Hp}");
                Console.WriteLine("=======================");
            }
        }
        public static void MostrarEnemigos(List<personaje> lista)
        {
            int aux = 1;
            Console.WriteLine("Enemigos");
            Console.WriteLine("=======================");
            for (int i = 2; i < 7; i++)
            {
                Console.WriteLine($"Nivel {aux}:");
                Console.WriteLine($"{lista[i].Name}:");
                Console.WriteLine($"Especie: {lista[i].Especie}");
                Console.WriteLine($"Origen: {lista[i].Origen}");
                Console.WriteLine("Caracteristicas:");
                Console.WriteLine($"Velocidad: {lista[i].Vel}");
                Console.WriteLine($"Destreza: {lista[i].Dest}");
                Console.WriteLine($"Fuerza: {lista[i].Fuerza}");
                Console.WriteLine($"Nivel: {lista[i].Nivel}");
                Console.WriteLine($"Armadura: {lista[i].Arm}");
                Console.WriteLine($"Vida: {lista[i].Hp}");
                Console.WriteLine("=======================");
                aux++;
            }
        }
        public static void MostrarEnemigo(List<personaje> lista, int Nivel)
        {
            Console.WriteLine($"Enemigo {Nivel}: {lista[Nivel+1].Name}");
            Console.WriteLine("=======================");
            Console.WriteLine($"Especie: {lista[Nivel+1].Especie}");
            Console.WriteLine($"Origen: {lista[Nivel+1].Origen}");
            Console.WriteLine("Caracteristicas:");
            Console.WriteLine($"Velocidad: {lista[Nivel+1].Vel}");
            Console.WriteLine($"Destreza: {lista[Nivel+1].Dest}");
            Console.WriteLine($"Fuerza: {lista[Nivel+1].Fuerza}");
            Console.WriteLine($"Nivel: {lista[Nivel+1].Nivel}");
            Console.WriteLine($"Armadura: {lista[Nivel+1].Arm}");
            Console.WriteLine($"Vida: {lista[Nivel+1].Hp}");
            Console.WriteLine("=======================");
        }
        public static void MostrarPj(List<personaje> lista, int Pj)
        {
            Console.WriteLine($"Tu personaje: {lista[Pj].Name}:");
            Console.WriteLine("=======================");
            Console.WriteLine($"Especie: {lista[Pj].Especie}");
            Console.WriteLine($"Origen: {lista[Pj].Origen}");
            Console.WriteLine("Caracteristicas:");
            Console.WriteLine($"Velocidad: {lista[Pj].Vel}");
            Console.WriteLine($"Destreza: {lista[Pj].Dest}");
            Console.WriteLine($"Fuerza: {lista[Pj].Fuerza}");
            Console.WriteLine($"Nivel: {lista[Pj].Nivel}");
            Console.WriteLine($"Armadura: {lista[Pj].Arm}");
            Console.WriteLine($"Vida: {lista[Pj].Hp}");
            Console.WriteLine("=======================");
        }
        public static void PasoNivel(List<personaje> lista, int Pj, int Nivel){
            if (Nivel !=5)
            {
                Console.WriteLine($"Superaste el nivel {Nivel}");
                Console.WriteLine("=======================");
                Console.WriteLine("Regenarion de 50 de vida");
                Console.WriteLine($"Vida: {lista[Pj].Hp}");
                Console.WriteLine("Sube 1 nivel");
                Console.WriteLine($"Nivel: {lista[Pj].Nivel}");
            }else{

                Console.WriteLine($"FELICIDADES");
                Console.WriteLine($"Superaste todos los niveles");
                Console.WriteLine("=======================");
                MostrarPj(lista, Pj);
            }

        }
        public static void GameOver(List<personaje> lista, int Pj, int Nivel)
        {
            Console.WriteLine("GAME OVER");
            Console.WriteLine($"Nivel alcanzado: {Nivel}");
            Console.WriteLine("=======================");
            MostrarPj(lista, Pj);
        }
    }
}