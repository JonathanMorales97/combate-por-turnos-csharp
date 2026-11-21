using System;
using System.Collections.Generic; // -> Necesario para usar listas

public class Personaje
{
    public string nombre;
    public int vida;
    public int ataque;

    public Personaje(string nombre, int vida, int ataque){
        this.nombre = nombre;
        this.vida = vida;
        this.ataque = ataque;
    }

    public void RecibirDanio(int cantidad){
        vida = Math.Max(0, vida - cantidad);
    }

    public void Atacar(Personaje objetivo){
        objetivo.RecibirDanio(ataque);
    }

    public bool EstaVivo(){
        return vida > 0;
    }

}



public class Program
{
    public static void Main()
    {
        Personaje heroe = new Personaje("Vane", 1000, 75);
        // Personaje enemigo = new Personaje("Jona", 100, 35);
        List<Personaje> enemigos = new List<Personaje>();
        enemigos.Add(new Personaje("e1", 100, 10));
        enemigos.Add(new Personaje("jona", 200, 50));
        enemigos.Add(new Personaje("Padre", 400, 80));

        foreach (Personaje enemigo in enemigos)
        {
            while (enemigo.EstaVivo())
            {
                heroe.Atacar(enemigo);
                Console.WriteLine("El enemigo " + enemigo.nombre + " sufrió un daño total de: " + heroe.ataque + ", su vida actual es: " + enemigo.vida);
                if (!enemigo.EstaVivo())
                {
                    Console.WriteLine("La heroína " + heroe.nombre + " venció a " + enemigo.nombre + " gloriosamente en combate");
                    break;
                }

                enemigo.Atacar(heroe);
                Console.WriteLine("La vida de la heroína es: " + heroe.vida + ", porque el ataque fue de: " + enemigo.ataque);
                if (!heroe.EstaVivo())
                {
                    Console.WriteLine("La heroína ha dado su vida en combate contra " + enemigo.nombre);
                    break;
                }
            }
            if (!heroe.EstaVivo())
            {
                Console.WriteLine("La heroína ha dado su vida en combate ante los " + enemigos.Count + " enemigos");
                break;
            }
        }
        if (heroe.EstaVivo())
        {
            Console.WriteLine("La heroína triunfó en su batalla contra los " + enemigos.Count + " enemigos");
        }
    }
}