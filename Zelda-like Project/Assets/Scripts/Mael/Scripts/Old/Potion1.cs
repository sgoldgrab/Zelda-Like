using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion1 : MonoBehaviour

{
    //private StatsScript health;

    private void Start()
    {
        StartCoroutine(TicTac());
    }

    IEnumerator TicTac()
    {

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //applique effet
            //health.CurrentVal -= x;


        }
        
    }
}
