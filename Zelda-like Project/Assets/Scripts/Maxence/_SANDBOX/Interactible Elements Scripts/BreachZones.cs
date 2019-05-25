using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachZones : MonoBehaviour
{
    private GameObject player;

    [Header("Spawning")]

    [SerializeField] private float range;

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

    public int count { get; set; }

    void Start()
    {
        player = GameObject.Find("PLAYER");

        timeBetweenSpawns = spawningTimer;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > range) return;

        Spawning();
    }

    void Spawning()
    {
        if (timeRate <= 0.0f && !listIsFull && count <= 2)
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

                count++;

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

        if (count <= 2) timeRate -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
