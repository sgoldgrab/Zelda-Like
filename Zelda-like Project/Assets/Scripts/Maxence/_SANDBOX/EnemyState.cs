using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    [SerializeField] private EnemyAnims enemyAnims;

    public Transform playerTransform { get; private set; }
    public PlayerMovement playerMovement { get; private set; }

    public delegate void EnemyKilled();
    public static event EnemyKilled whenEnemyDies;

    public delegate void EnemyHit();
    public static event EnemyHit whenEnemyHit;

    // HEALTH BAR INSTANTIATE
    [SerializeField] private GameObject enemyHealthBar;
    [SerializeField] private GameObject[] enemyHealthSegs;
    [SerializeField] private float offsetValue = 0.4f;
    [SerializeField] private float mainOffset;

    [SerializeField] private string theName;

    //TEST Instantiation
    [SerializeField] private float barSize;
    [SerializeField] private int segsNumber;

    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;

    // ON DEATH REQUIRED
    [SerializeField] private Collider2D[] enemyColliders;
    private EnemySpawner enemySpawner;
    private bool isDead = false;

    //CONDITIONS
    public bool enemyCanMove { get; set; } = true;
    public bool enemyCanUseSkill { get; set; } = true;

    //STATES
    public bool isStunned { get; set; } = false;
    public bool isMoving { get; set; } = true;
    public bool isProtected { get; set; } = false;
    public bool parry { get; set; } = false;

    void Start()
    {
        GameObject enemySpawnerMessenger = GameObject.FindWithTag("EnemySpawner");
        if (enemySpawnerMessenger != null) { enemySpawner = enemySpawnerMessenger.GetComponent<EnemySpawner>(); }

        GameObject playerMessenger = GameObject.FindWithTag("Player");
        if (playerMessenger != null) { playerTransform = playerMessenger.GetComponent<Transform>(); playerMovement = playerMessenger.GetComponent<PlayerMovement>(); }

        enemyHealthBar = Instantiate(enemyHealthBar, transform);
        InstantiateHealthBar();
    }

    void Update()
    {
        // fils de pute fait ton taff .exe

        if (isMoving && enemyCanMove) enemyAnims.MoveAnim(true);

        else if (!isMoving || !enemyCanMove) enemyAnims.MoveAnim(false);
    }

    public override void TakeDamage(int dmg)
    {
        if (isProtected) { parry = true; return; }

        for (int d = 0; d < dmg; d++)
        {
            if (!isDead)
            {
                if (health == 1)
                {
                    foreach (Collider2D col in enemyColliders) { col.enabled = false; }
                    enemySpawner.enemiesAlive = Mathf.Clamp(enemySpawner.enemiesAlive - 1, 0, 99);
                    whenEnemyDies?.Invoke();

                    isDead = true;
                }

                enemyHealthBar.GetComponent<EntityUI>().UITakeDamage(health, 1);

                base.TakeDamage(1);
            }
        }

        whenEnemyHit?.Invoke();

        enemyCanUseSkill = false;
        enemyCanMove = false;

        enemyAnims.DamageAnim(); // trigger the anim // the OnDeath() Method is activated through the playerAnims script, with the death animation.
    }

    public override void TakeHeal(int heal)
    {
        for (int h = 0; h < heal; h++)
        {
            if (health >= maxHealth)
            {
                return;
            }

            enemyHealthBar.GetComponent<EntityUI>().UITakeHealth(health, 1);

            base.TakeHeal(1);
        }
    }

    public void Recover()
    {
        enemyCanUseSkill = true;
        enemyCanMove = true;
    }

    //Old
    public void EnemyHealthBarDisplay()
    {
        int multiple = 1;
        float offsetX = 0.0f;
        int index = 0;

        foreach (GameObject prefab in enemyHealthSegs)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x + offsetX, transform.position.y + mainOffset);
            GameObject seg = Instantiate(enemyHealthSegs[index], spawnPosition, Quaternion.identity, enemyHealthBar.transform);
            seg.name = theName + " " + (index + 1).ToString();
            offsetX = 0.0f;
            index++;
            if (index % 2 == 1) //odd
            {
                offsetX += offsetValue * multiple;
            }
            else if (index % 2 == 0) //even
            {
                offsetX -= offsetValue * multiple;
                multiple++;
            }
        }
    }

    public void InstantiateHealthBar()
    {
        float segOffset = barSize / (segsNumber - 1);
        float offset = 0.0f;

        if (segOffset < minOffset)
        {
            segOffset = minOffset;
            barSize = segOffset * (segsNumber - 1);
        }

        if (segOffset > maxOffset)
        {
            segOffset = maxOffset;
            barSize = segOffset * (segsNumber - 1);
        }

        //Debug.Log(segOffset);

        float startPos = transform.position.x + (barSize / 2);

        for (int x = 0; x < segsNumber; x++)
        {
            Vector2 spawnPosition = new Vector2(startPos - offset, transform.position.y + mainOffset);
            GameObject seg = Instantiate(enemyHealthSegs[1], spawnPosition, Quaternion.identity, enemyHealthBar.transform);
            seg.name = theName + " " + (x + 1).ToString();
            offset += segOffset;
        }
    }
}
