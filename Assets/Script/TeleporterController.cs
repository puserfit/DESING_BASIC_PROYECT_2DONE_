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
		
        
        //gameObject.SetActive(false);       //Desactiva
        Destroy(gameObject);                //Destruye
        
        
        if(SceneManager.GetActiveScene().name=="NivelUno"){
            SceneManager.LoadScene("NivelDos");
        }
        else{
            SceneManager.LoadScene("NivelUno");
        }
        
    }


}
