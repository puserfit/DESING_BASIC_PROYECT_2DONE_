using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject character;
	
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x, transform.position.y, transform.position.z);
		
    }
}
