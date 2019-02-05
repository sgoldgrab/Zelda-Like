using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public GameObject player;

    private HealthPlayer playerHealth;

    private void Start()
    {
        
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
