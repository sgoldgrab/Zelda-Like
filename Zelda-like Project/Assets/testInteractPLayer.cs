using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInteractPLayer : MonoBehaviour
{
    public GameObject leTexteNarra;

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            leTexteNarra.SetActive(true);

        }
    }
}





