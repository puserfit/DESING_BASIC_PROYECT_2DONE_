using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Valores
	
	float nivelPiso = -0.61f;  //Este valor representa el nivel del piso para el personaje
	float limiteR = 11.68f;    //Este valor representa el limite Derecho de la camara para el personaje
	float limiteL = 2.05f;    //Este valor representa el limite Izquierdo de la camara para el personaje
	float velocidad = 4f;    //Velocidad de desplazamiento del personaje
	
	
    void Start()
    {
        //Personaje siempre inicia en la posicion (x -8.92--abajo,y -0.57---arriba)
		gameObject.transform.position = new Vector3(10.15f,nivelPiso,0);
    }

    
    void Update()
    {
		if(Input.GetKey("right")&& gameObject.transform.position.x < limiteR ){
			gameObject.transform.Translate(velocidad*Time.deltaTime, 0, 0);   //velocidad= 4f quiero que se mueva en x
			
		}
		
		else if(Input.GetKey("left")&& gameObject.transform.position.x > limiteL){
			gameObject.transform.Translate(-velocidad*Time.deltaTime, 0, 0);
					
		}
		
		if(Input.GetKey("space")){
			gameObject.transform.Translate(0, velocidad*Time.deltaTime, 0);
			
        }
    }
}
