using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTwoTest : MonoBehaviour
{
    private EnemyState enemyState;

    private bool enemyHit = false;

    private float timer = 0.25f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            GameObject enemy = col.transform.parent.parent.gameObject;

            enemyHit = true;

            enemyState = enemy.GetComponent<EnemyState>();

            enemy.GetComponent<Rigidbody2D>().MovePosition(transform.position);

            StartCoroutine(ComboEffect(2f));
        }
    }

    IEnumerator ComboEffect(float time)
    {
        enemyState.isStunned = true;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        Collider2D collider = GetComponent<Collider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(time);

        enemyState.isStunned = false;

        Destroy(gameObject);
    }

    private void Update()
    {
        if (!enemyHit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0) Destroy(gameObject);
        }
    }
}
