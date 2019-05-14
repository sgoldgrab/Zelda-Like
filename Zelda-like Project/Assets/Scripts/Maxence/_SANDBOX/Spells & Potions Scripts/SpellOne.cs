using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOne : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    private bool lockBool = true;

    private EnemyState enemyState;
    private Vector2 direction;

    private bool hasHit;

    public void SetPositions(Vector2 pos) // A DELETE
    {
        direction = pos.normalized;
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
        if (other.CompareTag("Enemy") && lockBool)
        {
            GameObject enemy = other.transform.parent.parent.gameObject;
            lockBool = false;

            enemyState = enemy.GetComponent<EnemyState>();

            StartCoroutine(EffectSpellOne(1, 2f));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        /*if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }

    IEnumerator EffectSpellOne(int damageValue, float time)
    {
        hasHit = true;

        yield return new WaitForSeconds(0.1f);

        enemyState.TakeDamage(damageValue);

        yield return new WaitForSeconds(time);

        enemyState.TakeDamage(damageValue);

        Destroy(gameObject);
    }
}
