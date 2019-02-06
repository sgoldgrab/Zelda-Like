using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private GameObject player;

    private HealthPlayer playerHealth;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerHealth = player.GetComponent<HealthPlayer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if(CompareTag("Player"))
        {

            playerHealth.health -= 5;

        }

    }

}
