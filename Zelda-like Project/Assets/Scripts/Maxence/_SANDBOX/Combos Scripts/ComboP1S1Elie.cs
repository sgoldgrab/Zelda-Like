using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP1S1Elie : MonoBehaviour
{
    private GameObject player;
    private PlayerState playerState;

    private List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Debug = new List<GameObject>();

    private bool used = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerState = player.GetComponent<PlayerState>();
    }

    void Update()
    {
        if(!used) DealDamage();

        //Destroy(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameObject enemy = col.transform.parent.parent.gameObject;

            if (!enemies.Contains(enemy)) enemies.Add(enemy);
        }
    }

    void DealDamage()
    {
        Debug = enemies;

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyState>().TakeDamage(1);
            playerState.TakeHeal(1);
            enemies.Remove(enemy);
        }

        used = true;
    }
}
