using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot2Spe1 : MonoBehaviour
{
    //2 dégâts aux ennemis touchés ; works just fine

    #region Variables
    private Health healthScript;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            healthScript = enemy.GetComponent<TemplarStatistics>().healthStats;

            healthScript.TakeDamage(2);

            Destroy(gameObject);

        }

    }

    private void Update()
    {
        
        if(!enemyHit)
        {

            timer -= Time.deltaTime;

            if(timer <= 0)
            {

                Destroy(gameObject);

            }

        }

    }

}
