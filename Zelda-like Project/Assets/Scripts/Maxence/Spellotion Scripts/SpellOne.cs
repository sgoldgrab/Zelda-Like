using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOne : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    private EnemyDormantEffects dormantEnemyScript;

    private PlayerAbilitiesBis playerAbilitiesScript;
    private Vector2 direction;

    private float dirX;
    private float dirY;

    private SpriteRenderer sprite;

    private bool hasHit;

    public void SetPositions(Vector2 pos) // A DELETE
    {
        direction = pos.normalized;
    }

    private void Start()
    {

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        transform.Translate(direction * speed * Time.deltaTime);

        if (timer <= 0.1f && !hasHit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Templar")) //Faudra mettre le tag "Enemy" sur tous les ennemis
        {
            //healthScript = other.GetComponent<TemplarStatistics>().healthStats;

            StartCoroutine(EffectSpellOne(1, 2f));

            sprite.enabled = false;
        }

        if (other.CompareTag("Obstacle") || other.CompareTag("Potion1") || other.CompareTag("Potion2"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EffectSpellOne(int damageValue, float time)
    {
        hasHit = true;

        yield return new WaitForSeconds(time);

        //healthScript.TakeDamage(damageValue);

        yield return new WaitForSeconds(time);

        //healthScript.TakeDamage(damageValue);

        Destroy(gameObject);
    }
}
