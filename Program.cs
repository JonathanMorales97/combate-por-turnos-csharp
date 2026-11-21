using System;
using System.Collections.Generic; // -> Necesario para usar listas

public class Personaje
{
    public string nombre;
    public int vida;
    public int ataque;
    private static Random azar = new Random();

    public Personaje(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.ataque = ataque;
    }

    public int RecibirDanio(int cantidad)
    {
        int vidaAntes = vida;
        vida = Math.Max(0, vida - cantidad);
        return vidaAntes - vida;
    }

    public int Atacar(Personaje objetivo)
    {
        int danio;
        int porcentaje = azar.Next(0, 100);
        if (porcentaje < 20)
        {
            danio = objetivo.RecibirDanio(ataque * 2);
            Console.WriteLine(nombre + " acertó un golpe crítico de daño " + danio);
        }
        else {
            danio = objetivo.RecibirDanio(ataque);
        }
       
        return danio;
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }

}



public class Program
{

    public static void Main()
    {
        Personaje heroe = new Personaje("Vane", 1000, 75);
        List<Personaje> enemigos = new List<Personaje>();
        enemigos.Add(new Personaje("e1", 200, 10));
        enemigos.Add(new Personaje("jona", 500, 50));
        enemigos.Add(new Personaje("Padre", 800, 80));

        foreach (Personaje enemigo in enemigos)
        {
            bool combate = Combatir(heroe, enemigo);
            if (!combate)
            {
                Console.WriteLine("La heroína cayó ante el enemigo: " + enemigo.nombre);
                break;
            }
        }
        if (heroe.EstaVivo())
        {
            Console.WriteLine("La heroína triunfó en su batalla contra los " + enemigos.Count + " enemigos");
        }
    }


    static bool Combatir(Personaje heroe, Personaje enemigo)
    {
        while (enemigo.EstaVivo())
        {
            int hecho = heroe.Atacar(enemigo);
            Console.WriteLine("El enemigo " + enemigo.nombre + " sufrió un daño total de: " + hecho + ", su vida actual es: " + enemigo.vida);
            if (!enemigo.EstaVivo())
            {
                Console.WriteLine("La heroína " + heroe.nombre + " venció a " + enemigo.nombre + " gloriosamente en combate");
                return true;
            }

            hecho = enemigo.Atacar(heroe);
            Console.WriteLine("La vida de la heroína es: " + heroe.vida + ", porque el ataque fue de: " + hecho);
            if (!heroe.EstaVivo())
            {
                return false;
            }
        }
        return heroe.EstaVivo();
    }
}