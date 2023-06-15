using clasePersonajes;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


personaje nuevo;
FabricaDePersonajes fp = new FabricaDePersonajes();
nuevo = fp.crearPersonaje();
Console.WriteLine(nuevo.Name);