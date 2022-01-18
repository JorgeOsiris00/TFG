# Guia del codigo:
En la carpeta Scripts: 
-CheckGround.cs : Dentro de la clase del personaje, este comprueba si esta en el suelo para multiples funciones en otras clases.

-CheckPoint.cs: Dentro de los objetos checkPoint, cuando el jugador pase por él, se guarda la posicion para reaparecer alli en caso de morir.

-DamageObject.cs: Dentro de objetos/enemigos que hagan daño, en el momento en que hagan colision con el jugador,destruyen al jugador.

-EnemySpikes.cs: Dentro de los objetos Spikes, cuando colisionen con el jugador, lo destruyen.

-GameFinish.cs: Dentro del director de cinematicas en el ultimo nivel, al acabar la cinematica,termina el juego.

-NivelAnterior.cs: Dentro de areas de colision en los extremos de los niveles,al entrar el jugador en el area, se carga el nivel anterior ( no se llega a usar).

-NivelSiguiente.cs: Igual que NivelAnterior, pero cargas el siguiente nivel.

-Platform.cs: Dentro de las plataformas, este Script permite al juagador subir desde abajo o bajar una vez esta arriba libremente ya que modifica el terreno dentro de la plataforma.

-PlatformDown.cs: Dentro de las plataformas de movimiento Vertical, permite este movimiento y el ajustar velocidad y posiciones dentro del motor de Unity

-PlatformMove.cs: Igual que la clase PlatformDown, pero con movimiento horizontal.
PlayerMove.cs: Dentro del jugador, permite el movimiento del jugador vertical y horizontal, ademas de cargar las animaciones correspondientes a traves de booleanos.

-PlayerRespawn.cs: Dentro de jugador, al morir este, se cargara su posicion en el ultimo checkpoint o en el inicio de la escena

( los scripts PlayermoveH y PlayerRespawn se tratan de clases iguales pero para el jugador cuando este Herido)

Dentro de la Carpeta Cinematics:

-Julia.cs: Dentro del NPC julia en su respectivo nivel, este Script coge un string del dialogo con en jugador ( este cambia segun la opcion que halla tomdado) para ejecutar que no se puede repetir el dialogo y la muerte de julia en funcion de la opcion que se eligiese.

-Pasillo.cs: Dentro del NPC del pasillo, de la misma forma que Julia.cs, se ejecutara una cinematica ( el NPC se ira o le dispararemos) en funcion de la opcion que hayamos elegido.

-VueltaPasillo.cs: Dentro de un area de colision en el UltimoNivel del juego, cuando entremos en el pasillo, se ejecutara la cinematica final y se avisara a GameFinish.cs para que finalice el juego.

Dentro de la carpeta Dialogue:

-DialogueManagerInk: Script lleno de metodos que se iran ejecutando para el correcto funcionamiento del sistema de dialogos( lectura de las frases de los archivos #.ink , que se muestren en el cuadro de dialogo para ser leido por el jugador, cargar las opciones disponibles, etc). Este es llamado por DiaolgueTrigger.cs 

-DialogueTrigger.cs: Dentro de cualquier NPC con un dialogo, cuando el jugador este cerca, indicara con una exclamacion el que haya un dialogo, cuando el jugador de al espacio ejecutara DialogueManagerInk.cs y quitara el movimiento al jugador hasta que termine el dialogo.

-DialogueVariables.cs: Script que permite la compilacion del Global.ink (tiene las variables comunes en los demas archivos que son los que permiten saber en C# que obcion se ha cogido en el sistema de dialogo). Debido a que Global.ink no es compiladao por Unity (un error a revisar a futuro) el script compila Global.ink.


Dentro de la carpeta Props:

-Trampoline.cs: dentro de los objetos trampolines ( las setas en el videojuego), estas al ser tocado por el jugador lo lanzan en vertical para hacer el efecto trampolin dentro de la ejecucion del juego.






