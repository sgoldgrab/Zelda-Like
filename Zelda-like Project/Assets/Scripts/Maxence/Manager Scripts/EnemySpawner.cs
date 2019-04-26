using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject[] enemies;

    public int enemiesAlive { get; set; } = 0;
    [SerializeField] private int maxEnemies;

    private float waitTime;
    [SerializeField] private float startWaitTime;

    [SerializeField] private float minX; [SerializeField] private float maxX; [SerializeField] private float minY; [SerializeField] private float maxY;

    private enum whoToSpawn { templar, mage }; // useless
    private whoToSpawn enemyToSpawn = whoToSpawn.mage; // bitch

    void Start ()
    {
        waitTime = 0.0f;
    }
	
	void Update ()
    {
        int index = Random.Range(0, 2);

        Spawn(enemies[index]);
    }

    void Spawn(GameObject enemy)
    {
        if (waitTime <= 0.1f && enemiesAlive < maxEnemies)
        {
            waitTime = startWaitTime;
            Instantiate(enemy, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), new Quaternion(0, 0, 0, 0));
            enemiesAlive += 1;
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}