using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public GameObject healthSegment;

    private bool isIdling = true;

    public virtual void IdleBehavior()
    {

        isIdling = true;

    }

    public virtual void AttackBehavior()
    {

        isIdling = false;

    }

    public override void OnDeath()
    {

        base.OnDeath();

    }

    public virtual void HealthBarDisplay(int health)
    {

        

    }

}
