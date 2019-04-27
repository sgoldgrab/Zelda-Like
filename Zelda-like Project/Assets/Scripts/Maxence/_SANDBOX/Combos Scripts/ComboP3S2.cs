using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP3S2 : MonoBehaviour
{
    //private ??? enemyMovements; JE SAIS PAS OU EST STOCKEE LA MOVE SPEED DE L'ENNEMI --> OUI JE SAIS COMMENT FAIRE (P-E)

    //private Invisible invisibleScript;

    private bool isTrigger = false;

    private float timer = 0.25f;

    private void Update()
    {
        if (!isTrigger)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject enemy = other.transform.parent.parent.gameObject;

        if (enemy.CompareTag("Enemy"))
        {
            isTrigger = true;

            //enemyMovements = enemy.GetComponent<???>();

            //invisibleScript = enemy.GetComponent<Invisible>();

            StartCoroutine(ComboEffect(8f));
        }
    }

    IEnumerator ComboEffect(float timer)
    {
        //enemyMovements.movementSpeed /= 2;

        //invisibleScript.enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(timer);

        //enemyMovements.movementSpeed *= 2;

        //invisibleScript.enabled = true;

        Destroy(gameObject);
    }

    
}
