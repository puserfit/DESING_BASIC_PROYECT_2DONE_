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
	  
	  //Se agrego posibilidad de esperar que el audio termine de reproducirse antes de realizar el cambio de escena.
	  
	  AudioSource audio = gameObject.GetComponent<AudioSource>();   //Intenta optener "AudioSource" del objeto al que esta adjunto este script
	  
	                                                                 //Si el objeto no tiene componente de audio esta variable será NULL
      
      if(audio == null){   // Si el objeto NO TIENE componente de AUDIO se cambia de escena inmediatamente
         SceneManager.LoadScene(_escena);
      }
      else{                // Si el objeto SI TIENE componente de AUDIO solo se cambia de escena cuando el audio haya terminado de reproducirse
         Debug.Log("[changeScene] AudioSource:  " + audio);             //el objeto si tiene el componente "AudioSource"
         StartCoroutine(changeSceneWithAudio(_escena, audio));          //Entonces se llama al metodo "changeSceneWithAudio(_escena, audio)"
      }                                                                 //para cambiar de escena de manera controlada despues que sonada el audio
      Debug.Log("CALL -> changeScene: " + _escena + " END");
   }

   private IEnumerator changeSceneWithAudio(int _escena, AudioSource audio){   //Metodo:"hangeSceneWithAudio(int _escena, AudioSource audio"
      Debug.Log("[changeScene]Yield Init");                                    //Este metodo es llamado cuando el objeto tiene un audio.
      yield return new WaitUntil(() => audio.isPlaying == false); // Se ejecuta esta línea hasta que la condición sea verdadera
      Debug.Log("[changeScene]Yield Over");                                      //indica cuando comienza y cuando termina uno de esperar
	  
	  
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
