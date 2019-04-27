using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot3Spe2 : MonoBehaviour
{
    //révèle les ennemis touchés et les ralentis ; works just fine

    #region Variables
    //private ??? enemyMovements; JE SAIS PAS OU EST STOCKEE LA MOVE SPEED DE L'ENNEMI

    private Invisible invisibleScript;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            //enemyMovements = enemy.GetComponent<???>();

            invisibleScript = enemy.GetComponent<Invisible>();

            StartCoroutine(ComboEffect(8f));

        }

    }

    IEnumerator ComboEffect(float timer)
    {

        //enemyMovements.movementSpeed /= 2;

        invisibleScript.enabled = false;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(timer);

        //enemyMovements.movementSpeed *= 2;

        invisibleScript.enabled = true;

        Destroy(gameObject);

    }

    private void Update()
    {

        if (!enemyHit)
        {

            timer -= Time.deltaTime;

            if (timer <= 0)
            {

                Destroy(gameObject);

            }

        }

    }

}
