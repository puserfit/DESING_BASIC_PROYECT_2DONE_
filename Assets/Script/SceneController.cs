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
