using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP2S2 : MonoBehaviour
{
    //pull les ennemis touchés au centre et les stun l ; works fine mais faudra trouver un meilleur moyen de stun --> /!\ NOT WORKING /!\

    private EnemyState enemyState;

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

            enemyState = enemy.GetComponent<EnemyState>();
            Rigidbody2D rb2D = enemy.GetComponent<Rigidbody2D>();

            rb2D.MovePosition(transform.position);

            StartCoroutine(ComboEffect(2f));
        }
    }

    IEnumerator ComboEffect(float time)
    {
        enemyState.isStunned = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(time);

        enemyState.isStunned = false;

        Destroy(gameObject);
    }
}
