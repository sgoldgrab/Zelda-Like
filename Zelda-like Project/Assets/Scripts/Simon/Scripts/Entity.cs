using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField] public int health;

    [SerializeField] public int maxHealth;

    [SerializeField] public int damage;

    [SerializeField] public float speed;

    public void TakeDamage(int damage)
    {

        health -= Mathf.Abs(damage);

    }

    public void TakeHeal(int heal)
    {

        health += Mathf.Abs(heal); 

        if(health > maxHealth)
        {

            health = maxHealth;

        }

    }

    public virtual void OnDeath()
    {

        Destroy(this.gameObject);

    }

}
