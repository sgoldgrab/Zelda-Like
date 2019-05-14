using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTwo : MonoBehaviour
{
    //OLD
    private Rigidbody2D rb2D;
    private bool isTrigger = false;
    [SerializeField] private float timer;
    [SerializeField] private int forceAmount;
    //

    private Vector3 direction;

    [SerializeField] private float pushDistance;
    [SerializeField] private float pushSpeed;

    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private float pushDuration;
    private float duration;

    public void SetPositions(Vector2 pos) // A DELETE
    {
        direction = pos.normalized;
    }

    void Start()
    {
        duration = pushDuration;
    }

    private void Update()
    {
        /*
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (isTrigger)
            {
                rb2D.AddForce(direction * forceAmount * -1);
            }

            Destroy(gameObject);
        }
        */

        Push();
    }

    void Push()
    {
        foreach (GameObject enm in enemies)
        {
            enm.transform.position = Vector2.MoveTowards(enm.transform.position, (enm.transform.position + direction) * pushDistance, pushSpeed * Time.deltaTime);

            if (duration <= 0.0f) Destroy(gameObject);

            else duration -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            isTrigger = true;

            enemies.Add(enemy);

            /*
            rb2D = enemy.GetComponent<Rigidbody2D>();
            rb2D.AddForce(direction * forceAmount);
            */
        }

        //Si un jour on y arrive, faut stopper le collider contre les murs (pas le détruire mais faire en sorte qu'il aille pas plus loin)
    }
}
