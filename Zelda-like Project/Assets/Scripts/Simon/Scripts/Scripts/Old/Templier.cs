using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templier : Enemy
{

    private void Start()
    {

        maxHealth = 4;
        health = maxHealth;
        damage = 1;
        speed = 2f;

    }

    public override void IdleBehavior()
    {

        base.IdleBehavior();

    }

    public override void AttackBehavior()
    {

        base.AttackBehavior();

    }

}
