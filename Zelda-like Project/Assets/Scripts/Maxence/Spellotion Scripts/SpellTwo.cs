using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTwo : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float timer;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //Faudra mettre le tag "Enemy" sur tous les ennemis
        {
            //dormantEnemyScript = other.gameObject.GetComponent<DormantEnemy>();

            //dormantEnemyScript.Spell2Effect();
        }

        if (other.CompareTag("Potion1") || other.CompareTag("Potion2"))
        {
            Destroy(gameObject);
        }

        //Si un jour on y arrive, faut stopper le collider contre les murs (pas le détruire mais faire en sorte qu'il aille pas plus loin)
    }
}
