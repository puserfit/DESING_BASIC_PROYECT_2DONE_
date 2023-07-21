using System.Collections;           //usar colecciones como listas y diccionarios
using System.Collections.Generic;
using UnityEngine;                  //Contiene las clases y funciones necesarias en Unity
using UnityEngine.UI;               //Para trabajar con componentes de Interfaz de Usuario (UI) en Unity
using TMPro;                        //Para trabajar con el paquete "TextMeshPro" para trabajar con textos


//CONTROLADOR DE ESTADISTICAS

//Se encarga de actualizar y mostrar:
//Las vidas
//El puntaje
//Los Items
//Los poderes



public class StatsController : MonoBehaviour     //Clase:StatsController   Hereda:MonoBehaviour 
                                                 //Permite que este codigo sea adjuntado a objetos en la escena y se ejecute en Unity    
{
    private TMP_Text    _score     = null;    //Componente:"TMP_Text"  Referencia:"_score"  Muesta el puntaje del jugador 
	
    private TMP_Text[]  _items     = null;    //Lista: "_items" contiene en este caso 3 componentes o recolectables .
                                              //"TMP_Text[]": Muestra de cada tipo de recolectable cuando recogi en total. Ejemplo manzana:4 piña: 6 uva:2.	
											  
    private Image[]     _powers    = null;    //Lista: "_powers" contiene en este caso 3 componentes o poderes que recoge el personaje mientras esta jugando .
	                                          //"Image[]": Representa visualmente los 3 poderes el jugador
											  
    private Image[]     _lives     = null;    //Lista: "_lives" contiene en este caso 3 componentes que son las vidas del personaje.
	                                          //"Image[]": Representa visualmente las vidas del jugador con una imagen
											  
    private Image[]     _NO_lives  = null;    //Lista: "_NO_lives " contiene en este caso 3 componentes que son las NO vidas del personaje.
	                                          // "Image[]": Representa visualmente las NO vidas del jugador con una imagen. En este caso es una imagen de vida vacia

	
    //Metodo:"Start()" Se inicializan los componentes 	
    void Start()                               
    {                                          //Componentes inicializados: "_score" , "_items", "_powers" , "_lives" , "_NO_lives"
	                                           //Se hace a traves de la jerarquia de GameObjects del objeto al que esta adjunto este codigo. (mirar Unity)
        _items    = new TMP_Text[3];
        _powers   = new Image[3];
        _lives    = new Image[3];
        _NO_lives = new Image[3];

        _lives[0]     = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
        _lives[1]     = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>();
        _lives[2]     = transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>();
        _NO_lives[0]  = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
        _NO_lives[1]  = transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Image>();
        _NO_lives[2]  = transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Image>();
        _score        = transform.GetChild(1).GetChild(0).gameObject.GetComponent<TMP_Text>();
        _items[0]     = transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>();
        _items[1]     = transform.GetChild(2).GetChild(1).GetChild(0).gameObject.GetComponent<TMP_Text>();
        _items[2]     = transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<TMP_Text>();
        _powers[0]    = transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>();
        _powers[1]    = transform.GetChild(3).GetChild(1).gameObject.GetComponent<Image>();
        _powers[2]    = transform.GetChild(3).GetChild(2).gameObject.GetComponent<Image>();
    }

	
	//Actualiza visualmente LAS VIDAS DEL JUGADOR
	//Metodo:"updateLives((bool live1, bool live2, bool live3)lives)" Se inicializan los componentes 
	                                                                         //Tupla:secuencia de valores agrupados.  no puede ser modificada 
																			 //EJM: tupla = (13, "mio", true) esta es una tupla triple
																			 
    public void updateLives((bool live1, bool live2, bool live3)lives){      //Recive como parametro una Tupla de 3 valores booleanos : "live1", "live2", "live3"
	                                                                         //Estos parametros indican si cada vida esta activa o no (llena o vacia)
        _lives[0].enabled = lives.live1?true:false;
        _NO_lives[0].enabled = !_lives[0].enabled;
        _lives[1].enabled = lives.live2?true:false;                          //a travez de "enabled" los componentes:"_lives" o "_NO_lives" 
        _NO_lives[1].enabled = !_lives[1].enabled;                           //se muestra u oculta visualmente las vidas llenas o vacias segun el valor booleano.
        _lives[2].enabled = lives.live3?true:false;
        _NO_lives[2].enabled = !_lives[2].enabled;
    }
    
	
	//Actualiza visualmente EL PUNTAJE DEL JUGADOR
	//Metodo:"updateScore(int score)"
    public void updateScore(int score){         //Parametro: "int score"  este es el valor del puntaje el cual es un entero "int"
	                                           
											   
        if(score < 0){                          //Si el puntaje es menonr que 0
            _score.text = "00000";             //Se muestra "00000"
        }
        else if(score > 99999){                 //Si el puntaje es mayor que 99999
            _score.text = "99999";              //Se muestra "99999"
        }
        else{                                        //Si el puntaje esta entre 0 y 99999.
            _score.text = score.ToString("00000");   //Se muestra con ceros a la izquierda para completar un total de cinco digitos
        }
    }

	//Actualiza visualmente LA CANTIDAD DE ITEMS que tiene el jugador 	
	//EJM: manzanas, peras, bananos ...que fueron recogidos por el jugador
	//Metodo:updateItems((int item1, int item2, int item3)items)
	
    public void updateItems((int item1, int item2, int item3)items){   //Recive como parametro una tupla de 3 valores enteros "item1", "item2", "item3"
	                                                                   //Representan la cantidad de cada tipo de item
																	   
		//PRIMER ITEM													   
        if(items.item1 < 0){                                           //Si la cantidad de Item es menonr que 0                
            _items[0].text = "00";                                     //Se muestra "00"
        }
        else if(items.item1 > 99){                                     //Si la cantidad de Item es mayor que 99
            _items[0].text = "99";                                     //Se muestra "99"
        }
        else{
            _items[0].text = items.item1.ToString("00");              //Si la cantidad de Item esta entre 0 y 99.
        }                                                             //Se muestra con ceros a la izquierda para completar un total de dos digitos

		//SEGUNDO ITEM
        if(items.item2 < 0){     
            _items[1].text = "00";
        }
        else if(items.item2 > 99){
            _items[1].text = "99";
        }
        else{
            _items[1].text = items.item2.ToString("00");
        }

		//TERCER ITEM
        if(items.item3 < 0){
            _items[2].text = "00";
        }
        else if(items.item3 > 99){
            _items[2].text = "99";
        }
        else{
            _items[2].text = items.item3.ToString("00");
        }
    }

	//Actualiza visualmente LOS PODERES DEL JUGADOR
	//Metodo:"updatePowers((bool item1, bool item2, bool item3)powers)" 
	
    public void updatePowers((bool item1, bool item2, bool item3)powers){   //Recibe como parametro una tupla de 3 valores booleanos "item1", "item2", "item3"
	                                                                        //Indican si cada poder esta activo o no
        Color tempColor;                                                    //A travez de la propiedad "color" de los componentes "_powers"
                                                                            //Se cambia el color de los poderes que estan:
        tempColor = _powers[0].color;                                       
        tempColor.r = powers.item1?1f:0f;
        tempColor.g = powers.item1?1f:0f;
        tempColor.b = powers.item1?1f:0f;
        tempColor.a = powers.item1?1f:0.2392f;                              //Activo:Blanco    
        _powers[0].color = tempColor;                                       //Desactivado: Opacidad mas baja 
                                                                            //segun el valor del booleano.
        tempColor = _powers[1].color;
        tempColor.r = powers.item2?1f:0f;
        tempColor.g = powers.item2?1f:0f;
        tempColor.b = powers.item2?1f:0f;
        tempColor.a = powers.item2?1f:0.2392f;
        _powers[1].color = tempColor;

        tempColor = _powers[2].color;
        tempColor.r = powers.item3?1f:0f;
        tempColor.g = powers.item3?1f:0f;
        tempColor.b = powers.item3?1f:0f;
        tempColor.a = powers.item3?1f:0.2392f;
        _powers[2].color = tempColor;
    }
}
