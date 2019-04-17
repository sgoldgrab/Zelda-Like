using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : EntityState
{
    [SerializeField] private EnemyAnims enemyAnims;
    [SerializeField] private EntityUI enemyUI;

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
    [SerializeField] private Collider2D[] enemyCollider;
    [SerializeField] private EnemySpawner enemySpawner;

    //STATES
    public bool enemyCanMove { get; set; } = true;
    public bool enemyCanUseSkill { get; set; } = true;

    void Start()
    {
        enemyHealthBar = Instantiate(enemyHealthBar, transform);

        //EnemyHealthBarDisplay();

        InstantiateHealthBar();
    }

    public override void TakeDamage(int dmg)
    {
        if (health <= 0)
        {
            foreach (Collider2D col in enemyCollider) { col.enabled = false; }
            enemySpawner.enemiesAlive -= 1;

            return;
        }

        Debug.Log(health + " " + dmg);
        enemyHealthBar.GetComponent<EntityUI>().UITakeDamage(health, dmg);

        base.TakeDamage(dmg); // loses health

        enemyCanUseSkill = false;
        enemyCanMove = false;

        enemyAnims.DamageAnim(); // trigger the anim // the OnDeath() Method is activated through the playerAnims script, with the death animation.
    }

    public override void TakeHeal(int heal)
    {
        if (health >= maxHealth)
        {
            return;
        }

        enemyHealthBar.GetComponent<EntityUI>().UITakeHealth(health, heal);

        base.TakeHeal(heal);
    }

    public void Recover()
    {
        enemyCanUseSkill = true;
        enemyCanMove = true;
    }

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

    //Testing
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

        Debug.Log(segOffset);

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
