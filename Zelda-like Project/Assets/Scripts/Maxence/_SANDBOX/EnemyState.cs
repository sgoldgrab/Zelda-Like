using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    [SerializeField] private EnemyAnims enemyAnims;
    [SerializeField] private EnemyBehaviorsManager enemyBehaviorsManager;

    public Transform playerTransform { get; private set; }
    public PlayerMovement playerMovement { get; private set; }

    public delegate void EnemyKilled();
    public static event EnemyKilled whenEnemyDies;

    public delegate void EnemyHit();
    public static event EnemyHit whenEnemyHit;

    // HEALTH BAR INSTANTIATE
    [Header("Health Bar Instance")]

    [SerializeField] private GameObject enemyHealthBar;
    [SerializeField] private GameObject[] enemyHealthSegs;
    
    [SerializeField] private float mainOffset;
    [SerializeField] private float offsetBetweenBars;

    [SerializeField] private string theName;

    //TEST Instantiation
    [SerializeField] private float barSize;

    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;

    [SerializeField] private bool decomposedBar;
    [SerializeField] private int maximumSegsOnABar;
    private int segSorting;
    [SerializeField] private Color[] barsColors;
    private int index;

    // ON DEATH REQUIRED
    [Header("Other")]

    public Collider2D[] enemyColliders;
    private BossFightSpawner bossFightSpawner;
    private BreachZones breachZones;
    private bool isDead = false; // DO NOT ERASE --> USEFUL

    [SerializeField] private bool bossSbire;
    [SerializeField] private bool breachSbire;

    //CONDITIONS
    public bool enemyCanMove { get; set; } = true;
    public bool enemyCanUseSkill { get; set; } = true;

    //STATES
    public bool isStunned { get; set; } = false; //useless
    public bool isMoving { get; set; } = true;
    public bool isProtected { get; set; } = false;
    public bool parry { get; set; } = false;

    //SOUND
    private AudioManager audioManager;

    public string enemy;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        if (GameObject.Find("DATA").GetComponent<GlobalData>().easyMode == true)
        {
            maxHealth -= 2;
            maximumSegsOnABar = maxHealth;
        }

        health = maxHealth;

        GameObject spawnerMessenger = GameObject.FindWithTag("BossSpawner");
        if (spawnerMessenger != null) { bossFightSpawner = spawnerMessenger.GetComponent<BossFightSpawner>(); }

        GameObject breachMessenger = GameObject.FindWithTag("BreachSpawner");
        if (breachMessenger != null) { breachZones = breachMessenger.GetComponent<BreachZones>(); }

        GameObject playerMessenger = GameObject.FindWithTag("Player");
        if (playerMessenger != null) { playerTransform = playerMessenger.GetComponent<Transform>(); playerMovement = playerMessenger.GetComponent<PlayerMovement>(); }

        enemyHealthBar = Instantiate(enemyHealthBar, transform);
        InstantiateHealthBar();
    }

    void Update()
    {
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
                    if (bossSbire) bossFightSpawner.enemyCount = Mathf.Clamp(bossFightSpawner.enemyCount - 1, 0, 99);
                    if (breachSbire) breachZones.count = Mathf.Clamp(breachZones.count - 1, 0, 99);

                    foreach (Collider2D col in enemyColliders) { col.enabled = false; }
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

        foreach (CombatSkillUpdate combatSkill in enemyBehaviorsManager.theSkills) combatSkill.ResetValues();

        enemyAnims.DamageAnim(); // trigger the anim // the OnDeath() Method is activated through the playerAnims script, with the death animation.

        if (isDead) audioManager.PlaySound(enemy + "Death");
        else audioManager.PlaySound(enemy + "Hurt");
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
                offsetX += offsetBetweenBars * multiple;
            }
            else if (index % 2 == 0) //even
            {
                offsetX -= offsetBetweenBars * multiple;
                multiple++;
            }
        }
    }

    public void InstantiateHealthBar()
    {
        float segOffset = barSize / (maximumSegsOnABar - 1);
        float offset = 0.0f;

        if (segOffset < minOffset)
        {
            segOffset = minOffset;
            barSize = segOffset * (maximumSegsOnABar - 1);
        }

        if (segOffset > maxOffset)
        {
            segOffset = maxOffset;
            barSize = segOffset * (maximumSegsOnABar - 1);
        }

        //Debug.Log(segOffset);

        float startPos = transform.position.x + (barSize / 2);

        for (int x = 0; x < maxHealth; x++)
        {
            if (decomposedBar && (x) == maximumSegsOnABar * (index + 1)) { offset = 0.0f; segSorting--; index++; mainOffset -= offsetBetweenBars; }

            Vector2 spawnPosition = new Vector2(startPos - offset, transform.position.y + mainOffset);
            GameObject seg = Instantiate(enemyHealthSegs[1], spawnPosition, Quaternion.identity, enemyHealthBar.transform);
            seg.name = theName + " " + (x + 1).ToString();
            seg.GetComponent<SpriteRenderer>().sortingOrder = segSorting;
            seg.GetComponent<SpriteRenderer>().color = barsColors[index];
            offset += segOffset;
        }
    }
}
