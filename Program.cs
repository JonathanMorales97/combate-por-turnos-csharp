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

    public virtual int Atacar(Personaje objetivo)
    {
        int danio;
        int porcentaje = azar.Next(0, 100);
        if (porcentaje < 20)
        {
            danio = objetivo.RecibirDanio(ataque * 2);
            Console.WriteLine(nombre + " acertó un golpe crítico de daño " + danio);
        }
        else
        {
            danio = objetivo.RecibirDanio(ataque);
        }

        return danio;
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }

}

public class Heroe : Personaje
{
    public int oro;

    public Heroe(string nombre, int vida, int ataque, int oro) : base(nombre, vida, ataque)
    {
        this.oro = oro;
    }

    public void Curar(int cantidad)
    {
        vida += cantidad;
    }
}

public class Enemigo : Personaje
{
    public int recompensa;

    public Enemigo(string nombre, int vida, int ataque, int recompensa) : base(nombre, vida, ataque)
    {
        this.recompensa = recompensa;
    }
}

public class Jefe : Enemigo
{
    public Jefe(string nombre, int vida, int ataque, int recompensa) : base(nombre, vida, ataque, recompensa) { }

    public override int Atacar(Personaje objetivo)
    {
        int atq = base.Atacar(objetivo);
        if (objetivo.EstaVivo())
        {
            atq += base.Atacar(objetivo);
        }
        return atq;
    }
}



public class Program
{

    public static void Main()
    {
        Heroe heroina = new Heroe("Vane", 1700, 75, 500);
        List<Enemigo> enemigos = new List<Enemigo>();
        enemigos.Add(new Enemigo("e1", 200, 10, 100));
        enemigos.Add(new Enemigo("jona", 500, 50, 350));
        enemigos.Add(new Enemigo("Padre", 800, 80, 500));
        enemigos.Add(new Jefe("Valentina", 950, 100, 1000));

        foreach (Enemigo enemigo in enemigos)
        {
            bool combate = Combatir(heroina, enemigo);
            if (!combate)
            {
                Console.WriteLine("La heroína cayó ante el enemigo: " + enemigo.nombre);
                break;
            }
        }
        if (heroina.EstaVivo())
        {
            Console.WriteLine("La heroína triunfó en su batalla contra los " + enemigos.Count + " enemigos");
        }
    }


    static bool Combatir(Heroe heroe, Enemigo enemigo)
    {
        while (enemigo.EstaVivo())
        {
            int hecho = heroe.Atacar(enemigo);
            Console.WriteLine("El enemigo " + enemigo.nombre + " sufrió un daño total de: " + hecho + ", su vida actual es: " + enemigo.vida);
            if (!enemigo.EstaVivo())
            {
                Console.WriteLine("La heroína " + heroe.nombre + " venció a " + enemigo.nombre + " gloriosamente en combate");
                heroe.oro += enemigo.recompensa;
                Console.WriteLine("Por su valentía recibe " + enemigo.recompensa + " de oro de recompensa, su oro actual es: " + heroe.oro);
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