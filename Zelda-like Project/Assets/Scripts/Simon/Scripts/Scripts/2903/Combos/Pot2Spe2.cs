using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot2Spe2 : MonoBehaviour
{
    //pull les ennemis touchés au centre et les stun l ; works fine mais faudra trouver un meilleur moyen de stun

    #region Variables
    private EnemyState enemyState;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            enemyState = enemy.GetComponent<EnemyState>();

            Rigidbody2D rb2D = enemy.GetComponent<Rigidbody2D>();

            rb2D.MovePosition(transform.position);

            StartCoroutine(ComboEffect(2f));

        }

    }

    IEnumerator ComboEffect(float time)
    {

        //enemyState.isStunned = true; AJOUTER LA BOOL IS STUNNED A PLAYER STATE OU SUR UN AUTRE SCRIPT

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(time);

        //enemyState.isStunned = false;

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
