# UnityArkanoid
Arkanoid for Unity3D
Versión de Unity Empleada: 2019.1.12f1

El ejercicio práctico ha sido desarrolado en un total de apróximadamente 8 horas, divididas entre el viernes y el domingo. Como todo desarrollo, el viernes comencé con el análisis de los requisitos necesarios así como el diseño orientado a objetos a seguir. Decidí realizar el juego con las siguientes clases:
 - Una clase para el jugador, en la que se definieran sus movimientos y colisiones.
 - Una clase para la pelota, donde se definieran sus colisiones.
 - Una clase para los tres bloques, pues la única diferencia es el número de impactos que sobrevive cada uno.
 - Una clase para generar los powerups.
 - Una clase padre con la definición de powerup y un método común para todos.
 - Clases individuales hijas de la clase padre de powerup, siendo cada una la implementación de los nuevos powerups (fácilemente escalable)

Además, como se puede comprobar en el proyecto existe una clase más, ya que me propuse como objetivo extra el autogenerar un nivel de manera aleatoria.

Para la realización de cada nivel (colocación de bloques) tardé aproximadamente entre 20 y 30 minutos.

La parte más costosa del ejercicio ha sido el ajuste del "bounce" o rebote de la pelota, ya que como se puede comprobar en el prototipo entregado, una vez se realizan varios rebotes, la fricción presupuesta no parece sufiente y la bola se acelera de más, dificultando el nivel. En esta parte pude pasar más de 4h. Además tampoco he podido corregir un error por el que la bola rebota en perpendicular y se queda moviéndose en horizontal.


El resto de tareas, powerups (incluidos dos extra aparte de los dos requeridos), movimientos del jugador, lógica del juego, apenas llevaron entre media y una hora cada una de ellas.