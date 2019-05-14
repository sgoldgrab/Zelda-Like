using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTwo : MonoBehaviour
{
    //OLD
    private Rigidbody2D rb2D;
    [SerializeField] private int forceAmount;
    //

    private bool isTrigger = false;
    [SerializeField] private float timeBeforeDestroy;
    private float timer;

    private Vector3 direction;

    [SerializeField] private float pushDistance;
    [SerializeField] private float pushSpeed;

    private List<GameObject> enemies = new List<GameObject>();
    private int numberOfEnemies;

    [SerializeField] private float pushDuration;
    private float duration;

    public void SetPositions(Vector2 pos)
    {
        direction = pos.normalized;
    }

    void Start()
    {
        duration = pushDuration;

        timer = timeBeforeDestroy;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.1f && !isTrigger)
        {
            Destroy(gameObject);
        }

        Push();
    }

    void Push()
    {
        foreach (GameObject enm in enemies)
        {
            Debug.Log(direction);

            enm.transform.position = Vector2.MoveTowards(enm.transform.position, enm.transform.position + (direction * pushDistance), pushSpeed * Time.deltaTime);

            if (duration <= 0.0f)
            {
                enm.GetComponent<EnemyState>().enemyCanMove = true;
                enm.GetComponent<EnemyState>().enemyCanUseSkill = true;

                numberOfEnemies--;

                if (numberOfEnemies <= 0) Destroy(gameObject);
            }
        }

        duration -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            isTrigger = true;

            enemies.Add(enemy);
            numberOfEnemies++;

            enemy.GetComponent<EnemyState>().enemyCanMove = false;
            enemy.GetComponent<EnemyState>().enemyCanUseSkill = false;

            /*
            isTrigger = true;

            rb2D = enemy.GetComponent<Rigidbody2D>();
            rb2D.AddForce(direction * forceAmount);
            */
        }

        //Si un jour on y arrive, faut stopper le collider contre les murs (pas le détruire mais faire en sorte qu'il aille pas plus loin)
    }
}
