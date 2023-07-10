//Se importa las clases y funciones de Unity y el sistema de gestion de escena.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//clase:PauseController  (componente de Unity) y Hereda:MonoBehaviour
public class PauseController : MonoBehaviour
{    
    [SerializeField] GameObject pauseMenu;     //GameObject:pauseMenu  (representa el PANEL en la interfaz de usuario)
	                                           //Atributo:SerializeField   (permite que este campo sea visible en Unity..para que se pueda
											   //asisgnar el boton de pausa al arrastrar y soltar el objeto correspondiente en el campo)
	
	                                         // Asignar el panel PauseMenu a este objeto desde 
                                            // el elemento 'script' en el inspector, una vez
                                            // este script se haya asociado a los botones.
    
	
	//BOTON PAUSA
    public void Pause(){                   //Metodo:Pause     GameObject:pauseMenu
        Debug.Log("BUTTON -> Pause");      //este metodo se llama cuando el jugador presiona el boton de pausa
        pauseMenu.SetActive(true);          //se establece el GameObject:pauseMenu en activo "SetActive(true)"...el panel de pausa se mostrara en la ui.
        Time.timeScale = 0f;                //Time.timeScale = 0f Al tener esto. Pausamos el tiempo de juego.
    }

	
	//BOTON CONTINUAR
    public void Resume(){                   //Metodo:Resume  (se llamaba cuando el jugador presiona el boton de reanudar)
        Debug.Log("BUTTON -> Resume");      // Debug que muestra la persona oprimio el boton.
        pauseMenu.SetActive(false);         //se establece el GameObject:pauseMenu en inactivo "SetActive(false)"...el panel de pausa se oculatara en la ui.
        Time.timeScale = 1f;                //como esta en 1 reanuda el tiempo de juego.
    }

	
	//BOTON REGRESAR MENU
    public void goMenu(int _escena){        //medodo:goMenu(int _escena   (se llama cuando el jugador presiona el boton de ir al menu principal)
        Time.timeScale = 1f;                //Time.timeScale en 1 para asegurarse de que el tiempo de juego se reanude correctamente
        SceneManager.LoadScene(_escena);     //se carga la escena especificada por el parametro:_escena
    }
    
	//BOTON AUDIO
    public void Audio(){                     //metodo:Audio (se llama cuando el jugador presiona el boton de audio)
        Debug.Log("BUTTON -> Audio");        //Imprime un mensaje de depuracion indicando que se ha presionado el boton de audio.
    }
}
