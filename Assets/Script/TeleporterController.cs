using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour
{
	//Sonido 
	[SerializeField] private AudioSource teleporter_SFX;       //Sonido Cuando coja la Copa
	
	private void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Copa Transladora a otro nivel");
		teleporter_SFX.Play();
		
		//Esperar que termine la reproduccion del sonido
		StartCoroutine(goNextLevel(teleporter_SFX.clip.length)); // Pasa el nivel con un "delay" para que alcance a sonar el audio
        gameObject.GetComponent<Renderer>().enabled = false;      // La moneda desaparece
        
        //gameObject.SetActive(false);       //Desactiva
        //Destroy(gameObject);                //Destruye        
    }
	
	    // Aquí está la lógica del paso de nivel después de la pausa suficiente para que suene el audio
    private IEnumerator goNextLevel(float delay){
        yield return new WaitForSeconds(delay); 
        Destroy(gameObject);

        if(SceneManager.GetActiveScene().name=="NivelUno"){
            SceneManager.LoadScene("NivelDos");                                 //Cambiar al NivelDos si esta en NivelUno
        }
        else if (SceneManager.GetActiveScene().name=="NivelDos"){
            SceneManager.LoadScene("NivelTres");                                //Cambiar al NivelTres si esta en NivelDos                                        
        }
		else if (SceneManager.GetActiveScene().name=="NivelTres"){
            //SceneManager.LoadScene("NivelUno");                                 //Cambiar al NivelUno si esta en NivelTres
        }
    }

}
