using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion2 : MonoBehaviour
{

    //private StatsScript damage;

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
            //damage.CurrentVal += x;
            // ou sinon
                //timeBtwAttacks -= 0;


        }
        
    }
}
