using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public GameObject player;
    private HealthPlayer playerHealth;

    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    public GameObject groupEnemies;
    private Transform enemiesTransform;

    private GameObject playerHealthOne;
    private GameObject playerHealthTwo;
    private GameObject playerHealthThree;
    private GameObject playerHealthFour;
    private GameObject playerHealthFive;

    private void Start()
    {

        enemiesTransform = groupEnemies.GetComponent<Transform>();

        playerHealth = player.GetComponent<HealthPlayer>();

        GameObject enemy1 = Instantiate(enemy1Prefab);
        GameObject enemy2 = Instantiate(enemy2Prefab);

        enemy1.transform.parent = enemiesTransform;
        enemy2.transform.parent = enemiesTransform;

        playerHealthOne = GameObject.Find("SEG1");
        playerHealthTwo = GameObject.Find("SEG2");
        playerHealthThree = GameObject.Find("SEG3");
        playerHealthFour = GameObject.Find("SEG4");
        playerHealthFive = GameObject.Find("SEG5");

    }

    private void Update()
    {
        
        if(playerHealth.isDead)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for(int i = 0; i < enemies.Length; i++)
            {

                Destroy(enemies[i]);

            }

            if(Input.GetKeyDown(KeyCode.R))
            {

                playerHealth.isDead = false;

                playerHealthOne.SetActive(true);
                playerHealthTwo.SetActive(true);
                playerHealthThree.SetActive(true);
                playerHealthFour.SetActive(true);
                playerHealthFive.SetActive(true);

                player.transform.position = new Vector3(0, 4, 0);

                GameObject enemy1 = Instantiate(enemy1Prefab);
                GameObject enemy2 = Instantiate(enemy2Prefab);

                enemy1.transform.parent = enemiesTransform;
                enemy2.transform.parent = enemiesTransform;

            }

        }

    }

}
