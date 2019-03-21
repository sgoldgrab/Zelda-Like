using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float sightRange;

    //ATTACK
    public float attackSpeed;
    public float attackRange;
    public float attackCoolDown;
    public float attackRate;
    public float attackRateCoolDown;

    //IDLE
    public float idlePauseTime;
    public float idleWalkDistance;

    void IdleBehavior()
    {

    }

    void DetectedBehavior()
    {

    }
}
