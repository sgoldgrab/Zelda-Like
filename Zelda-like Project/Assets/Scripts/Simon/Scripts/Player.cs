using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private void Start()
    {

        maxHealth = 5;
        health = maxHealth;
        damage = 1;
        speed = 3.2f;

    }

    private void FixedUpdate()
    {
        


    }

}
