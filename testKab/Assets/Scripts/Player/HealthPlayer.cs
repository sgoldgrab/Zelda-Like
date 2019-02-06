using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    public float health;

    public float maxHealth = 25f;

    public bool isDead = false;

    public GameObject healthBar;
    private Slider slider;

    private void Start()
    {

        health = maxHealth;

        slider = healthBar.GetComponent<Slider>();

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

        slider.value = health;

    }

    private void PlayerDead()
    {

        isDead = true;

    }

}
