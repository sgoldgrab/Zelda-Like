using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject mage;
    public GameObject templar;

    [HideInInspector] public int enemiesAlive = 0;
    public int maxEnemies;

    private float waitTime;
    [SerializeField]
    private float startWaitTime;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    [SerializeField]
    private enum whoToSpawn { templar, mage };
    [SerializeField]
    private whoToSpawn enemyToSpawn = whoToSpawn.mage;

    // TEST ONLY
    public bool templarIsHere;

    void Start ()
    {
        waitTime = 0.0f;
    }
	
	void Update ()
    {
        if(enemyToSpawn == whoToSpawn.mage)
        {
            Spawn(mage);
        }

        if(enemyToSpawn == whoToSpawn.templar)
        {
            Spawn(templar);
        }
    }

    void Spawn(GameObject enemy)
    {
        if (waitTime <= 0.1f && enemiesAlive < maxEnemies)
        {
            waitTime = startWaitTime;
            //
            Instantiate(enemy, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), new Quaternion(0, 0, 0, 0)); // check the surcharges boi
            enemiesAlive += 1;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}