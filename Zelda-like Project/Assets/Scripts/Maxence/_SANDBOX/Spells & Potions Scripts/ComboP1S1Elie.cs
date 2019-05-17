using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP1S1Elie : MonoBehaviour
{
    private GameObject player;

    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private float time;
    private float timer;

    private void Awake()
    {
        timer = time;
        player = GameObject.Find("PLAYER");
    }

    void Update()
    {
        //DealDamage();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameObject enemy = col.transform.parent.parent.gameObject;

            enemy.GetComponent<EnemyState>().TakeDamage(1);
            player.GetComponent<PlayerState>().TakeHeal(1);

            //if (!enemies.Contains(enemy))
            //enemies.Add(enemy);
        }
    }

    void DealDamage()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyState>().TakeDamage(1);
            player.GetComponent<PlayerState>().TakeHeal(1);
        }

        enemies.Clear();
    }
}
