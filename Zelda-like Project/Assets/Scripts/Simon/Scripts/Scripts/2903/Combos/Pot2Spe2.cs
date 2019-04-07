using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot2Spe2 : MonoBehaviour
{
    //pull les ennemis touchés au centre et les stun l ; works fine mais faudra trouver un meilleur moyen de stun

    #region Variables
    private EnemyStats enemyScript;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            enemyScript = enemy.GetComponent<TemplarStatistics>().otherStats;

            Rigidbody2D rb2D = enemy.GetComponent<Rigidbody2D>();

            rb2D.MovePosition(transform.position);

            StartCoroutine(ComboEffect(2f));

        }

    }

    IEnumerator ComboEffect(float time)
    {

        float temper = enemyScript.movementSpeed;

        enemyScript.movementSpeed = 0;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(time);

        enemyScript.movementSpeed = temper;

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
