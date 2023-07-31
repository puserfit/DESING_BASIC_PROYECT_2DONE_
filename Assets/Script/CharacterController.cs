using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Valores
	
	
	//float nivelPiso = -0.61f;  //Este valor representa el nivel del piso para el personaje
	float nivelDelTecho = 6.8f;       //Este valor es el Y...comienza en el aire..Gravedad: x:0 y:9.85         7.36f
	float limiteR = 11.68f;    //Este valor representa el limite Derecho de la camara para el personaje
	float limiteL = -9f;    //Este valor representa el limite Izquierdo de la camara para el personaje       185.04f
	float velocidad = 4f;    //Velocidad de desplazamiento del personaje  4f
	float fuerzaSalto = 95;     //x veces la masa del personaje (2 codigo) //la fuerzaSalto es 50 su propio peso (el peso del personaje)  50-70-60-90
	
	float fuerzaDesplazamiento = 300;   //Fuerza en Newton que va a tener el personaje ...es grande por que tiene rozamiento (drag)
	
	bool enElPiso = true;     //tiene que tocar el piso 
	
	
    void Start()
    {
        //Personaje siempre inicia en la posicion (x -8.92--abajo,y -0.57---arriba)         
		gameObject.transform.position = new Vector3(-9f,nivelDelTecho,0);                         //10.15f                     //(-9f,nivelDelTecho,0)  185.04f
		Debug.Log("INIT");      //lo que aparece en las "" es lo que se va a decir en la consola.
    }

    
    void Update()
    {
		if(Input.GetKey("right")&& enElPiso){
			Debug.Log("RIGHT"); 
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento,0));
			
		}
		
		else if(Input.GetKey("left")&& gameObject.transform.position.x > limiteL){
			Debug.Log("LEFT");
			gameObject.transform.Translate(-velocidad*Time.deltaTime, 0, 0);
		}
		
		if(Input.GetKeyDown("space") && enElPiso){
            Debug.Log("UP - enElPiso: " + enElPiso);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSalto*Physics2D.gravity[1]*gameObject.GetComponent<Rigidbody2D>().mass));
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

    
}