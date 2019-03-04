using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion3 : MonoBehaviour
{
    //en gros tu récupère ta fonction qui gère le champ de visu du joueur
    //private PlayerController damage;

    private void Start()
    {
        StartCoroutine(TicTac());
    }

    IEnumerator TicTac()
    {

        yield return new WaitForSeconds(5);

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //applique effet
            //fieldOfVision.value += X
            //augmente le champ de visu du joueur


        }
       
    }
}
