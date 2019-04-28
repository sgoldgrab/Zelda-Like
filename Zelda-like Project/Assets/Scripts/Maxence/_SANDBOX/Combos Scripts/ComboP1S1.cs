using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP1S1 : MonoBehaviour
{
    //1 dégâts aux ennemis touchés, 1 de heal au player pour chaque ennemi touché ; works just fine --> /!\ NOT YET /!\

    private GameObject player;
    private PlayerState playerState;

    private int enemyCount = 0;

    private bool isTrigger = false; // anciennement enemyHit

    private float timer = 1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerState = player.GetComponent<PlayerState>();
    }

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

            /*
            enemy.GetComponent<EnemyState>().TakeDamage(1);

            enemyCount += 1;

            Debug.Log(enemyCount);

            while (enemyCount > 0)
            {
                playerState.TakeHeal(1);

                enemyCount--;
            }
            */
        }

        if (isTrigger)
        {
            foreach (GameObject foe in enemyList)
            {
                foe.GetComponent<EnemyState>().TakeDamage(1);

                playerState.TakeHeal(1);
            }

            Destroy(gameObject);
        }
    }
}
