using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP2S1 : MonoBehaviour
{
    //2 dégâts aux ennemis touchés ; works just fine --> /!\ NOT YET /!\ --> same as ComboP1S1

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
        List<GameObject> enemyList = new List<GameObject>();

        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            enemyList.Add(enemy);

            isTrigger = true;
        }

        if (isTrigger)
        {
            foreach (GameObject foe in enemyList)
            {
                foe.GetComponent<EnemyState>().TakeDamage(2);
            }

            Destroy(gameObject);
        }

        /*if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            isTrigger = true;

            enemy.GetComponent<EnemyState>().TakeDamage(2);

            Destroy(gameObject);
        }*/
    }
}
