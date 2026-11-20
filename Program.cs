using System;

public class Personaje
{
	public string nombre;
	public int vida = 100;
	public int ataque;
	public void RecibirDanio(int cantidad)
	{
		vida -= cantidad;
	}

	public void Atacar(Personaje objetivo)
	{
		objetivo.RecibirDanio(ataque);
	}
}

public class Program
{
	public static void Main()
	{
		Personaje heroe = new Personaje();
		heroe.nombre = "Vane";
		heroe.ataque = 26;
		Personaje enemigo = new Personaje();
		enemigo.nombre = "Jona";
		enemigo.ataque = 25;
		while (heroe.vida > 0 && enemigo.vida > 0)
		{
			heroe.Atacar(enemigo);
			if (enemigo.vida <= 0)
			{
				Console.WriteLine("El héroe venció gloriosamente al enemigo");
				break;
			}

			enemigo.Atacar(heroe);
			if (heroe.vida <= 0)
			{
				Console.WriteLine("El héroe ha dado su vida en combate");
				break;
			}
		}
	}
}
