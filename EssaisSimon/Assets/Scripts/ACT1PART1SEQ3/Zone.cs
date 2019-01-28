using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    public bool enemyOnZone = false;
    public bool isOccupied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player") && !enemyOnZone)
        {

            isOccupied = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {

            isOccupied = false;

        }

    }

    

}
