using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP2S1 : MonoBehaviour
{
    //2 dégâts aux ennemis touchés ; works just fine --> /!\ NOT YET /!\ --> same as ComboP1S1

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
            enemyState.TakeDamage(2);

            Destroy(gameObject);
        }
    }
}
