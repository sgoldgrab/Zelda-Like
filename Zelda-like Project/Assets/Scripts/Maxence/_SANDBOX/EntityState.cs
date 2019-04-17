﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public delegate void DeathAction();
    public static event DeathAction OnDeathAction;

    [SerializeField] protected int maxHealth;
    public int health { get; private set; }

    void Awake()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int dmg)
    {
        health = Mathf.Clamp(health - dmg, 0, maxHealth);
    }

    public virtual void TakeHeal(int heal)
    {
        health = Mathf.Clamp(health + heal, 0, maxHealth);
    }

    public void OnDeath() // activated via the playerAnims script.
    {
        OnDeathAction();

        Destroy(gameObject);
    }
}