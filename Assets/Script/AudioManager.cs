//Importar los namespace para las clases y componentes en Unity.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class AudioManager : MonoBehaviour
{
    public static bool sound = true;        //variable(statica-boleana):sound ...Valor True lo que significa que el sonido esta activo
    
	//Variables
	//Almacenar los sprite que representa los iconos de sonido...soundOn:Activo   soundOff:Desactivado
	public Sprite soundOn;      //variable(publica-sprite):soundOn
    public Sprite soundOff;     //variable(publica-sprite): soundOff
	
	
	
	//Se da click en el boton para acivar sonido.
    public void SoundOn()
    {
        gameObject.GetComponent<Image>().sprite = soundOn;  //cambia el icono del sonido...Imagen del objeto:nombre "Image"---Cambia icono "soundOn"
        sound = true;                                       //variable sound es verdades....es decir esta sonando la musica.
    }
	
	
	//Se da click en el boton para desactivar sonido.
    public void SoundOff() 
    {
        gameObject.GetComponent<Image>().sprite = soundOff;     //cambia el icono del sonido...Imagen del objeto:nombre "Image"---Cambia icono "soundOff"
        sound = false;                                          //variable sound es falsa....es decir NO esta sonando la musica.
    }
	
	
	
	//Se coloca un boton para cambiar el estado del sonido.
    public void ChangeSound()
    {
		//Sonido Activo (sound=true)
        if (sound)
        {
            gameObject.GetComponent<Image>().sprite = soundOff;    //Cambia icono del objeto:Image----al icono "SoundOff"
            sound = false;                                          //estable la variable "sound" como falsa
        }
		
		//Sonido Desactivado (sound=false)
        else
        {
            gameObject.GetComponent<Image>().sprite = soundOn;    //Cambia icono del objeto:Image----al icono "SoundOn"
            sound = true;                                         //estable la variable "sound" como true.
        }
    }
}

