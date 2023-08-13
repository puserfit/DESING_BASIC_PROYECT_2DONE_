using System.Collections;                              //JUEGO CAMI
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Valores
	
	private int vidas = 3;
	
	//float nivelPiso = -0.61f;  //Este valor representa el nivel del piso para el personaje
	float nivelDelTecho = 7.15f;       //Este valor es el Y...comienza en el aire..Gravedad: x:0 y:9.85     nivel 2: 6.8f /   7.36f
	float limiteR = 11.68f;    //Este valor representa el limite Derecho de la camara para el personaje
	float limiteL = -9.07f;    //Este valor representa el limite Izquierdo de la camara para el personaje    nivel 2:-9f /  185.04f
	float velocidad = 4f;    //Velocidad de desplazamiento del personaje  4f
	float fuerzaSalto = 60;     //x veces la masa del personaje (2 codigo) //la fuerzaSalto es 50 su propio peso (el peso del personaje)  95  70  60
	
	float fuerzaDesplazamiento = 300;   //Fuerza en Newton que va a tener el personaje ...es grande por que tiene rozamiento (drag)  300   500
	
	bool enElPiso = false;     //tiene que tocar el piso 
	
	
	//Sonidos
	[SerializeField] private AudioSource salto_SFX;        //Sonido Salto    
	                                                       //Asigna valores a campos directamente desde el Editor de Unity
	                                                       //Los campos provados de una clase se vuelve accesibles desde el inspector de UnityEngine
    void Start()
    {
        //Personaje siempre inicia en la posicion (x -8.92--abajo,y -0.57---arriba)         
		gameObject.transform.position = new Vector3(-8.97f,nivelDelTecho,0);     //nivel2:-9f  //10.15f  CUANDO COMIENZA JUEGO  //(-9f,nivelDelTecho,0)  185.04f
		Debug.Log("INIT");      //lo que aparece en las "" es lo que se va a decir en la consola.
		Debug.Log("VIDAS: " + vidas);          //Numero de vidas que tiene
    }

    
    void Update()
    {
		
		//Personaje se mantenga recto
		if(gameObject.transform.rotation.z>0.3 || gameObject.transform.rotation.z< -0.3){    //esta en radianes  0.3radianes = 17 graddos  -π y -π= -3.14 y +3.14
			Debug.Log("ROTATION: " + gameObject.transform.rotation.z);                       //registra en la consola el valor actual de la rotacion en el ejeZ
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);                   //restablece la rotacion del personaje en ceros grados en el eje X,Y,Z
			                                                                                //restablece a una posicion vertical "Quaternion.Euler"
			
		
		}
		
		if(Input.GetKey("right")&& enElPiso){
			Debug.Log("RIGHT"); 
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento,0));
			gameObject.GetComponent<Animator>().SetBool("running", true);                             //bandera para run
			
		}
		
		else if(Input.GetKey("left")&& gameObject.transform.position.x > limiteL){
			Debug.Log("LEFT");
			gameObject.transform.Translate(-velocidad*Time.deltaTime, 0, 0);
			gameObject.GetComponent<Animator>().SetBool("running", true);                              //bandera para run
		}
		
		//Condicional para pasar del estado "Idle" a "Run"
		if( !(Input.GetKey("right")|| Input.GetKey("left"))){
			gameObject.GetComponent<Animator>().SetBool("running", false);
			
		}
		
		//SALTO
		if(Input.GetKeyDown("space") && enElPiso){
            Debug.Log("UP - enElPiso: " + enElPiso);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSalto*Physics2D.gravity[1]*gameObject.GetComponent<Rigidbody2D>().mass));
            salto_SFX.Play();                              //Le esta diciendo que cuando salte REPRODUSCA ESE SONIDO
			enElPiso = false;
        }
	}
	
	
	
	private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Ground"){
            enElPiso = true;
            Debug.Log("GROUND COLLISION");
        }
		else if(collision.transform.tag == "Obstaculo"){     //Para cuando hay obstaculos
            enElPiso = true;
            Debug.Log("OBSTACLE COLLISION");
        }
    }
	
	//Vamos a colocar el objeto vacio para que lance el evento cuando el personaje cae al vacio
	private void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Caida del personaje");
		
		//Cuando el personaje cae al vacio le disminuyo una vida...........devolver al personaje al punto inicial 
		vidas -= 1;
		
		Debug.Log("VIDAS: " + vidas);
        if (vidas <=0){
			Debug.Log("GAME OVER");                                                  //Cuando se le acaba el numero de vidas
			vidas = 3;                                                               //quitar linea
		}
		gameObject.transform.position = new Vector3(-8.97f,nivelDelTecho,0);         //Personaje regresa a la misma posicion                      

    }
}