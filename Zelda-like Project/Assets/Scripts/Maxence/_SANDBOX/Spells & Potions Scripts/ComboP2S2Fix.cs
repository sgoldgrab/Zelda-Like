using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP2S2Fix : MonoBehaviour
{
    [SerializeField] private float pullSpeed;

    private bool triggered = false;
    [SerializeField] private float TimeLeft;
    private float timer;

    private List<GameObject> enemies = new List<GameObject>();
    private int numberOfEnemies;

    [SerializeField] private float pullDuration;
    private float duration;

    void Start()
    {
        duration = pullDuration;

        timer = TimeLeft;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.1f && !triggered)
        {
            Destroy(gameObject);
        }

        Pull();
    }

    void Pull()
    {
        foreach (GameObject enm in enemies)
        {
            enm.transform.position = Vector2.MoveTowards(enm.transform.position, transform.position, pullSpeed * Time.deltaTime);

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

            triggered = true;

            enemies.Add(enemy);
            numberOfEnemies++;

            enemy.GetComponent<EnemyState>().enemyCanMove = false;
            enemy.GetComponent<EnemyState>().enemyCanUseSkill = false;
        }
    }
}
