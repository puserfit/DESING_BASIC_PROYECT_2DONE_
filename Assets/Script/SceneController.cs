using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   //gestion de escenas


//CAMBIAR PANTALLA

 //gestion de escenas

public class SceneController : MonoBehaviour  //clase:SceneController   hereda:MonoBehaviour
{
    public void changeScene(int _escena){           //metodo: "changeScene" permite cambiar la escena cargada actualmente     parametro:"_escena" numero entero
      Debug.Log("CALL -> changeScene: " + _escena);    //Mensaje de depuracion: "debug.Log"...indica que ha llamdo a este metodo.   parametro: _escena
	  
	  
	  //se agrego mas codigo
	  AudioSource audio = gameObject.GetComponent<AudioSource>(); //Si el objeto no tiene componente de audio esta variable será NULL
      
      if(audio == null){   // Si el objeto NO TIENE componente de AUDIO se cambia de escena inmediatamente
         SceneManager.LoadScene(_escena);
      }
      else{                // Si el objeto SI TIENE componente de AUDIO solo se cambia de escena cuando el audio haya terminado de reproducirse
         Debug.Log("[changeScene] AudioSource:  " + audio);
         StartCoroutine(changeSceneWithAudio(_escena, audio));
      }
      Debug.Log("CALL -> changeScene: " + _escena + " END");
   }

   private IEnumerator changeSceneWithAudio(int _escena, AudioSource audio){
      Debug.Log("[changeScene]Yield Init");
      yield return new WaitUntil(() => audio.isPlaying == false); // Se ejecuta esta línea hasta que la condición sea verdadera
      Debug.Log("[changeScene]Yield Over");
	  //fin.
	  
	  
	                                                   //changeScene: 1       si paso de splash (0) al menu(1)...y comienzo en la de splash
      SceneManager.LoadScene(_escena);               //"SceneManagement.LoadScene" cargar la escena correspondiente al parametro:"_escena"
   }
   
   //SALIR DEL JUEGO

   public void quitGame(){      //"quitGame" salir del juego
      #if UNITY_EDITOR          //Verificar si el juego se esta ejecutando en el editor de Unity.
        UnityEditor.EditorApplication.isPlaying = false;         //Detener el juego en el editor.
      #endif
      Application.Quit();         //salir de la aplicacion.
   }
}
