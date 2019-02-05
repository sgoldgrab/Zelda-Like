using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{

    public int health;

    public int maxHealth = 25;

    public bool isDead = false;

    private void Start()
    {

        health = maxHealth;

    }

    private void Update()
    {
        
        if(health <= 0)
        {

            PlayerDead();

        }

        if(health > maxHealth)
        {

            health = maxHealth;

        }

    }

    private void PlayerDead()
    {

        isDead = true;

    }

}
