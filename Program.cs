using System;

public class Personaje
{
    public string nombre;
    public int vida;
    public int ataque;

    public Personaje(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.ataque = ataque;
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
    }

    public void Atacar(Personaje objetivo)
    {
        objetivo.RecibirDanio(ataque);
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
        Personaje heroe = new Personaje("Vane", 100, 20);
        Personaje enemigo = new Personaje("Jona", 100, 35);
        while (heroe.EstaVivo() && enemigo.EstaVivo())
        {
            heroe.Atacar(enemigo);
            if (!enemigo.EstaVivo())
            {
                Console.WriteLine("El héroe venció gloriosamente al enemigo");
                break;
            }

            enemigo.Atacar(heroe);
            if (!heroe.EstaVivo())
            {
                Console.WriteLine("El héroe ha dado su vida en combate");
                break;
            }
        }
    }
}