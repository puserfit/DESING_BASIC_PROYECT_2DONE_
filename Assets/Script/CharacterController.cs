using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Valores
	
	
	float nivelPiso = -0.61f;  //Este valor representa el nivel del piso para el personaje
	float nivelDelTecho = 5.41f;       //Este valor es el Y...comienza en el aire..Gravedad: x:0 y:9.85
	float limiteR = 11.68f;    //Este valor representa el limite Derecho de la camara para el personaje
	float limiteL = 2.05f;    //Este valor representa el limite Izquierdo de la camara para el personaje
	float velocidad = 4f;    //Velocidad de desplazamiento del personaje
	float fuerzaSalto = 35;     //x veces la masa del personaje (2 codigo) //la fuerzaSalto es 50 su propio peso (el peso del personaje)
	
	float fuerzaDesplazamiento = 400;   //Fuerza en Newton que va a tener el personaje ...es grande por que tiene rozamiento (drag)
	
	bool enElPiso = true;     //tiene que tocar el piso 
	
	
    void Start()
    {
        //Personaje siempre inicia en la posicion (x -8.92--abajo,y -0.57---arriba)
		gameObject.transform.position = new Vector3(10.15f,nivelDelTecho,0);
		Debug.Log("INIT");      //lo que aparece en las "" es lo que se va a decir en la consola.
    }

    
    void Update()
    {
		if(Input.GetKey("right")&& gameObject.transform.position.x < limiteR ){
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
    }

    
}