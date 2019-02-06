using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameObject player;
    private HealthPlayer playerHealth;

    public GameObject enemyHealthBarPrefab;

    private GameObject enemyHealthBar;

    private EnemyHealthBar enemyHealthScript;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerHealth = player.GetComponent<HealthPlayer>();

        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector2(transform.position.x, transform.position.y +1), Quaternion.identity);

        enemyHealthBar.transform.parent = transform;

        enemyHealthScript = enemyHealthBar.GetComponent<EnemyHealthBar>();



    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("AttackMouse0"))
        {

            enemyHealthScript.Damaged();

        }

        if(other.CompareTag("Player"))
        {

            playerHealth.TakeDamage();

        }

    }

}
