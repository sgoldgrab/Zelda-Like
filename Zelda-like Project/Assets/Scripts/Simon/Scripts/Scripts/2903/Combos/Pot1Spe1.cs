using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot1Spe1 : MonoBehaviour
{
    //1 dégâts aux ennemis touchés, 1 de heal au player pour chaque ennemi touché ; la boucle for pète un câble la pute

    #region Variables
    private Health playerHealth;

    private GameObject player;

    private Health enemyHealth;

    public int enemyCount = 0;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerStatistics>().healthStats;

    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            enemyHealth = enemy.GetComponent<TemplarStatistics>().healthStats;

            enemyCount += 1;

            enemyHealth.TakeDamage(1);

            for (int i = 0; i < enemyCount; i++)
            {

                playerHealth.TakeHeal(1);

            }

            Destroy(gameObject);

        }

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
