using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breach : MonoBehaviour
{
    //States
    [Header("States")]

    [SerializeField] private float startHealth;
    private float health;

    [SerializeField] private float mainTimer;
    private float mainTime;

    [SerializeField] private float blockedTimer;
    private float blockedTime;

    [SerializeField] private int maxDamageGiven;
    private int damageCount;

    [SerializeField] private string theTag;

    private bool blocked = false;

    //Spawning
    [Header("Spawning")]

    [SerializeField] private float spawnTimeRate;
    private float timeRate;

    [SerializeField] private float spawningTimer;
    private float timeBetweenSpawns;

    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<int> quantity;
    private int idx;

    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private bool listIsFull = false;
    private int index = 0;

    [SerializeField] private List<GameObject> bonusEnemies;
    [SerializeField] private List<int> bonusQuantity;
    private int bonusIdx;

    //OnDeath
    [SerializeField] private GameObject key;

    void Start()
    {
        health = startHealth;
        blockedTime = blockedTimer;

        timeRate = spawnTimeRate;
        timeBetweenSpawns = spawningTimer;
    }

    void Update()
    {
        StateManager();

        Spawning();

        if (health <= 0)
        {
            Instantiate(key, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    void Spawning()
    {
        if (timeRate <= 0.0f && !listIsFull)
        {
            foreach (GameObject enemy in enemies)
            {
                for (int q = 0; q < quantity[idx]; q++)
                {
                    enemiesToSpawn.Add(enemy);
                }

                idx++;
            }

            listIsFull = true;
            idx = 0;
        }

        if (listIsFull)
        {
            if (timeBetweenSpawns <= 0.0f)
            {
                Instantiate(enemiesToSpawn[index], transform.position, transform.rotation);
                
                timeBetweenSpawns = spawningTimer;
                index++;

                GetComponentInChildren<Animator>().SetTrigger("spawn");
            }

            if (index >= enemiesToSpawn.Count) // instantiation is finished
            {
                listIsFull = false;
                timeRate = spawnTimeRate;
                timeBetweenSpawns = 0.0f;
                index = 0;
                enemiesToSpawn.Clear();
            }

            timeBetweenSpawns -= Time.deltaTime;
        }

        timeRate -= Time.deltaTime;
    }

    void BonusSpawn()
    {
        foreach (GameObject enemy in bonusEnemies)
        {
            for (int q = 0; q < bonusQuantity[bonusIdx]; q++)
            {
                enemiesToSpawn.Add(enemy);
            }

            bonusIdx++;
        }

        bonusIdx = 0;
    }

    void StateManager()
    {
        if (mainTime <= 0.0f && !blocked)
        {
            mainTime = mainTimer;
            damageCount = 0;
        }

        mainTime -= Time.deltaTime;

        if (blocked)
        {
            if (blockedTime <= 0.0f)
            {
                blockedTime = blockedTimer;
                damageCount = 0;
                blocked = false;
                GetComponentInChildren<Animator>().SetLayerWeight(1, 0f);
            }

            blockedTime -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == theTag && !blocked)
        {
            damageCount++;
            health--;

            Debug.Log(health + " " + damageCount);

            GetComponentInChildren<Animator>().SetTrigger("damage");

            if (damageCount >= maxDamageGiven)
            {
                blocked = true;
                GetComponentInChildren<Animator>().SetLayerWeight(1, 1f);

                timeRate = 0.0f;
                BonusSpawn();
            }
        }
    }
}
