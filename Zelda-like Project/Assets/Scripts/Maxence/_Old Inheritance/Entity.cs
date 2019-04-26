using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //GENERAL
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float resistance;

    [SerializeField] protected float damage;
    [SerializeField] protected float initDamage;

    [SerializeField] protected float speed;
    [SerializeField] protected float initSpeed;

    //COMPLEX DAMAGE --> Probably going to move into the "specific enemy stats" scripts and "player stats" script, as it is very specific variables
    [SerializeField] protected int damageIndex;
    [SerializeField] protected int bonusDamage;
    [SerializeField] protected int damageRateCoolDown;

    //BOOLS
    protected bool isAlive = true;
    protected bool canMove = true;
    protected bool canAttack = true;
    protected bool isHit; // possibly useless /!\

    protected bool immunity = false;

    //COMPONENTS
    protected Collider2D theCollider;
}
