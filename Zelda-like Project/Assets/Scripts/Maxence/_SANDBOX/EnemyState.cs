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

    // ON DEATH REQUIRED
    [SerializeField] private Collider2D[] enemyCollider;
    [SerializeField] private EnemySpawner enemySpawner;

    //STATES
    public bool enemyCanMove { get; private set; } = true;
    public bool enemyCanAttack { get; private set; } = true;

    void Start()
    {
        enemyHealthBar = Instantiate(enemyHealthBar, transform);

        EnemyHealthBarDisplay();
    }

    public override void TakeDamage(int dmg)
    {
        if (health <= 0)
        {
            foreach (Collider2D col in enemyCollider) { col.enabled = false; }
            enemySpawner.enemiesAlive -= 1;

            return;
        }

        enemyUI.UITakeDamage(health, dmg);

        base.TakeDamage(dmg); // loses health

        enemyCanAttack = false;
        enemyCanMove = false;

        enemyAnims.DamageAnim(); // trigger the anim // the OnDeath() Method is activated through the playerAnims script, with the death animation.
    }

    public override void TakeHeal(int heal)
    {
        if (health >= maxHealth)
        {
            return;
        }

        enemyUI.UITakeHealth(health, heal);

        base.TakeHeal(heal);
    }

    public void Recover()
    {
        enemyCanAttack = true;
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
}
