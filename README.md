# combate-por-turnos-csharp

\## QUE HACE

El programa lo que hace es un combate por turnos a través de clases entre un héroe y un enemigo a los cuales se los puede llamar como deseen y ponerle el ataque como gusten.


\## COMO EJECUTARLO

solo pégalo en dotnetfiddle.net y pulsa Run para ver los resultados. 

<img width="1917" height="830" alt="image" src="https://github.com/user-attachments/assets/e3c18a27-7b90-4e03-8413-500c6566790a" />


\## QUE PRACTIQUE (20/11/26)

Se pone en práctica lo que viene siendo clases, comprobaciones y bucles a través de dos personajes un héroe y un enemigo que luchan entre si.


\## QUE PRACTIQUE (21/11/26)

Añadiendo el constructor y el métodos que devuelven bool como el EstaVivo todo al personaje, tambien se usa el metodo en los if del bucle while para el combate.

Se añade listas de enemigos para que el héroe combata por turnos con cada uno de ellos, se recorre las listas con un foreach y se anida un bucle while para verficar si los enemigos estan vivos o si el héroe sigue vivo.

Se aumenta un método para el combate dentro del Program, que se encargue del combate entre dos personajes y devuelva al Main el resultado.

Se modifica los métodos de Atacar y Recibir daño para que devuelvan el daño real, además se incorpora golpes críticos que hacen el doble de daño que el ataque normal. Se muestra en pantalla el daño real que se causa al personaje en combate.

Por último se aplica el concepto de Herencia con el Heroe, Enemigo y Jefe, donde la clase Jefe hace un override del método Atacar y ataca dos veces por turno.
