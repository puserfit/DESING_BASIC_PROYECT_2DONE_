using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject character;                                             //CODIGO PROFE
	//public GameObject fallDetector;
	//public float limiteIzquierdo = 6.55f;
	//public float distanciaHorizontal = 16f;    //lo que le quito a la camara
	
    void Update()
    {
	transform.position = new Vector3(character.transform.position.x, transform.position.y, transform.position.z);            //CODIGO PROFE
	
	//Poner limite a la camara para que no me muestre espacios vacios
	
	//Sigue al personaje Horizontalmente con el limite izquierdo
	//float cameraX = Mathf.Max(character.transform.position.x, limiteIzquierdo);
	//transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
	
	//Ajusta la posicion del "FallDetector" para que siempre este a la misma distancia horizontal que el personaje 
	//float fallDetectorX = character.transform.position.x + distanciaHorizontal;
	//fallDetector.transform.position = new Vector3(fallDetectorX, fallDetector.transform.position.y, fallDetector.transform.position.z);
		
    }
}
