using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTwo : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private bool isTrigger = false;

    [SerializeField] private float timer;

    [SerializeField] private int forceAmount;

    [SerializeField] private Vector2 direction;

    public void SetPositions(Vector2 pos) // A DELETE
    {
        direction = pos.normalized;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (isTrigger)
            {
                rb2D.AddForce(direction * forceAmount * -1);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            isTrigger = true;

            rb2D = enemy.GetComponent<Rigidbody2D>();
            rb2D.AddForce(direction * forceAmount);
        }

        //Si un jour on y arrive, faut stopper le collider contre les murs (pas le détruire mais faire en sorte qu'il aille pas plus loin)
    }
}
