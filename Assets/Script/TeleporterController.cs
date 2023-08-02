using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Copa Transladora a otro nivel");
        
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
