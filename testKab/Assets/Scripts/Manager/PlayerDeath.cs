using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public GameObject player;
    private HealthPlayer playerHealth;

    public GameObject enemy1;
    public GameObject enemy2;

    private void Start()
    {

        playerHealth = player.GetComponent<HealthPlayer>();

        Instantiate(enemy1);
        Instantiate(enemy2);

    }

    private void Update()
    {
        
        if(playerHealth.isDead)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] enemiesHealth = GameObject.FindGameObjectsWithTag("EnemyHealthBar");

            for(int i = 0; i < enemies.Length; i++)
            {

                Destroy(enemies[i]);

            }

            for (int i = 0; i < enemiesHealth.Length; i++)
            {

                Destroy(enemiesHealth[i]);

            }

            if(Input.GetKeyDown(KeyCode.R))
            {

                playerHealth.isDead = false;
                playerHealth.health = playerHealth.maxHealth;
                player.transform.position = new Vector3(0, 0, 0);

                Instantiate(enemy1);
                Instantiate(enemy2);

            }

        }

    }

}
