using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveInfo
{
    public List<GameObject> enemies;
    public List<int> quantity;
}

[System.Serializable]
public class BonusWaveInfo
{
    public List<GameObject> bonusEnemies;
    public List<int> bonusQuantity;
}

public class BossFightSpawner : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private EnemyState bossState;

    [Header("Spawning")]

    [SerializeField] private float timeBetweenEachWave;
    [SerializeField] private float timeAfterBigWave;
    private float timeWave;

    private bool bigWave = false;

    [SerializeField] private float timeBetweenEachSpawn;
    private float timeSpawn;

    [SerializeField] private List<WaveInfo> wavesEnemies;

    [SerializeField] private List<BonusWaveInfo> bonusWavesEnemies;

    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private bool listIsFull = false;
    private int spawnIndex = 0;

    private int waveIndex;
    private int bonusWaveIndex;

    public int enemyCount { get; set; }

    private int currentPhase;

    [SerializeField] private List<Transform> spawners;
    public List<Transform> wannaSpawn { get => spawners; private set => spawners = value; }

    [Header("General")]

    [SerializeField] private GameObject door;
    private bool theFightHasBegan;

    void Update()
    {
        if (!theFightHasBegan) return;

        PhaseUpdate();

        if (timeWave <= 0.0f && !listIsFull && enemyCount <= 0)
        {
            CreateWave(currentPhase);
        }

        if (listIsFull)
        {
            Spawning();
        }

        if (enemyCount <= 0) timeWave -= Time.deltaTime;
    }

    void PhaseUpdate()
    {
        if ((bossState.health <= (2 * bossState.SetMaximumHealth) / 3 && currentPhase == 0) || (bossState.health <= bossState.SetMaximumHealth / 3 && currentPhase == 1))
        {
            CreateBigWave(currentPhase);

            currentPhase++;
        }
    }

    void Spawning()
    {
        if (timeSpawn <= 0.0f)
        {
            Vector2 spawnPoint = spawners[Random.Range(0, spawners.Count)].position;

            Instantiate(enemiesToSpawn[spawnIndex], spawnPoint, transform.rotation);
            enemyCount++;

            timeSpawn = timeBetweenEachSpawn;
            spawnIndex++;
        }

        if (spawnIndex >= enemiesToSpawn.Count) // instantiation is finished
        {
            timeSpawn = 0.0f;
            spawnIndex = 0;
            enemiesToSpawn.Clear();

            if (bigWave) timeWave = timeAfterBigWave;
            else timeWave = timeBetweenEachWave;

            listIsFull = false;
            bigWave = false;
        }

        timeSpawn -= Time.deltaTime;
    }

    private void CreateWave(int phase)
    {
        foreach (GameObject enemy in wavesEnemies[phase].enemies)
        {
            for (int q = 0; q < wavesEnemies[phase].quantity[waveIndex]; q++)
            {
                enemiesToSpawn.Add(enemy);
            }

            waveIndex++;
        }

        listIsFull = true;
        waveIndex = 0;
    }

    private void CreateBigWave(int endPhase)
    {
        foreach (GameObject enemy in bonusWavesEnemies[endPhase].bonusEnemies)
        {
            for (int q = 0; q < bonusWavesEnemies[endPhase].bonusQuantity[bonusWaveIndex]; q++)
            {
                enemiesToSpawn.Add(enemy);
            }

            bonusWaveIndex++;
        }

        bigWave = true;
        listIsFull = true;
        bonusWaveIndex = 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetActive(true);
            theFightHasBegan = true;
        }
    }
}
